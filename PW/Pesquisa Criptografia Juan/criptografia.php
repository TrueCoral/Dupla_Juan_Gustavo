<?php

$textoOriginal = "Olá mundo";
$senhaOriginal = "minhaSenha123";


if (!empty($_POST["texto"])) {
    $textoOriginal = $_POST["texto"];
}
if (!empty($_POST["senha"])) {
    $senhaOriginal = $_POST["senha"];
}


$hashSha256 = hash("sha256", $textoOriginal);
$hashMd5    = md5($textoOriginal);   // apenas para efeito de comparação/estudo
$hashSha1   = sha1($textoOriginal);  // apenas para efeito de comparação/estudo


$hashSenha = password_hash($senhaOriginal, PASSWORD_DEFAULT);
$senhaConfere = password_verify($senhaOriginal, $hashSenha);

$hashArgon2 = null;
if (defined("PASSWORD_ARGON2ID")) {
    $hashArgon2 = password_hash($senhaOriginal, PASSWORD_ARGON2ID);
}

$chaveHmac = "chave-secreta-do-servidor";
$hmac = hash_hmac("sha256", $textoOriginal, $chaveHmac);

$algoritmoOpenssl = "aes-256-cbc";
$chaveOpenssl = openssl_digest("chave-super-secreta", "sha256", true); // 32 bytes
$ivLen = openssl_cipher_iv_length($algoritmoOpenssl);
$iv = openssl_random_pseudo_bytes($ivLen);

$textoCifradoOpenssl = openssl_encrypt(
    $textoOriginal,
    $algoritmoOpenssl,
    $chaveOpenssl,
    0,
    $iv
);

$textoDecifradoOpenssl = openssl_decrypt(
    $textoCifradoOpenssl,
    $algoritmoOpenssl,
    $chaveOpenssl,
    0,
    $iv
);

$sodiumDisponivel = extension_loaded("sodium");
$textoCifradoSodium = null;
$textoDecifradoSodium = null;

if ($sodiumDisponivel) {
    $chaveSodium = sodium_crypto_secretbox_keygen();
    $nonce = random_bytes(SODIUM_CRYPTO_SECRETBOX_NONCEBYTES);

    $textoCifradoSodium = sodium_crypto_secretbox(
        $textoOriginal,
        $nonce,
        $chaveSodium
    );

    $textoDecifradoSodium = sodium_crypto_secretbox_open(
        $textoCifradoSodium,
        $nonce,
        $chaveSodium
    );
}

function paraHex($bin) {
    return $bin === null ? "(indisponível)" : bin2hex($bin);
}
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
<meta charset="UTF-8">
<title>Tipos de criptografia no PHP</title>
<style>
    body {
        font-family: Arial, Helvetica, sans-serif;
        max-width: 900px;
        margin: 40px auto;
        padding: 0 20px;
        line-height: 1.5;
        color: #222;
    }
    h1 { text-align: center; }
    h2 {
        margin-top: 40px;
        border-bottom: 2px solid #2c5aa0;
        padding-bottom: 4px;
        color: #2c5aa0;
    }
    .caixa {
        background: #f4f6fa;
        border: 1px solid #dde3ee;
        border-radius: 6px;
        padding: 14px 18px;
        margin: 10px 0;
        word-break: break-all;
        font-family: Consolas, monospace;
        font-size: 14px;
    }
    .rotulo {
        font-family: Arial, sans-serif;
        font-weight: bold;
        display: block;
        margin-bottom: 4px;
        color: #444;
    }
    .ok { color: #1a7a1a; font-weight: bold; }
    .erro { color: #b00020; font-weight: bold; }
    form {
        background: #fff8e6;
        border: 1px solid #f0d98a;
        border-radius: 6px;
        padding: 16px 20px;
        margin-bottom: 30px;
    }
    label { display: block; margin-top: 10px; font-weight: bold; }
    input[type=text], input[type=password] {
        width: 100%;
        padding: 6px 8px;
        margin-top: 4px;
        box-sizing: border-box;
    }
    button {
        margin-top: 14px;
        padding: 8px 18px;
        background: #2c5aa0;
        color: #fff;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }
    button:hover { background: #1e3f73; }
    .nota {
        font-size: 13px;
        color: #666;
        margin-top: 4px;
    }
</style>
</head>
<body>

<h1>Tipos de criptografia disponíveis no PHP</h1>
<p>
    Esta página demonstra, de forma prática, os principais recursos de
    criptografia e hashing que o PHP oferece nativamente. Altere o texto
    e a senha abaixo para ver os resultados mudarem em tempo real.
</p>

<form method="post">
    <label for="texto">Texto para hash / criptografia:</label>
    <input type="text" id="texto" name="texto"
           value="<?= htmlspecialchars($textoOriginal) ?>">

    <label for="senha">Senha para o exemplo de password_hash():</label>
    <input type="text" id="senha" name="senha"
           value="<?= htmlspecialchars($senhaOriginal) ?>">

    <button type="submit">Gerar exemplos</button>
</form>

<!-- 1) HASH SIMPLES -->
<h2>1. Hash simples — função hash()</h2>
<p>Gera uma "impressão digital" do conteúdo. O processo não é reversível.</p>

<div class="caixa">
    <span class="rotulo">SHA-256 (recomendado para integridade de dados)</span>
    <?= $hashSha256 ?>
</div>

<div class="caixa">
    <span class="rotulo">MD5 (obsoleto — não usar para senhas)</span>
    <?= $hashMd5 ?>
</div>

<div class="caixa">
    <span class="rotulo">SHA-1 (obsoleto — não usar para senhas)</span>
    <?= $hashSha1 ?>
</div>

<!-- 2) PASSWORD_HASH -->
<h2>2. Hash de senha — password_hash() / password_verify()</h2>
<p>Forma recomendada para armazenar senhas. Usa salt aleatório automaticamente.</p>

<div class="caixa">
    <span class="rotulo">Hash gerado (PASSWORD_DEFAULT)</span>
    <?= $hashSenha ?>
</div>

<?php if ($hashArgon2): ?>
<div class="caixa">
    <span class="rotulo">Hash gerado (PASSWORD_ARGON2ID)</span>
    <?= $hashArgon2 ?>
</div>
<?php endif; ?>

<p>
    Verificação da senha digitada contra o hash acima:
    <?= $senhaConfere
        ? '<span class="ok">senha confere ✔</span>'
        : '<span class="erro">senha não confere ✘</span>' ?>
</p>

<!-- 3) HMAC -->
<h2>3. HMAC — hash_hmac()</h2>
<p>Combina o conteúdo com uma chave secreta para permitir verificar integridade e autenticidade.</p>

<div class="caixa">
    <span class="rotulo">HMAC-SHA256</span>
    <?= $hmac ?>
</div>

<!-- 4) OPENSSL -->
<h2>4. Criptografia simétrica reversível — OpenSSL (AES-256-CBC)</h2>
<p>A mesma chave é usada para criptografar e descriptografar. O texto original pode ser recuperado.</p>

<div class="caixa">
    <span class="rotulo">IV (vetor de inicialização, em hexadecimal)</span>
    <?= bin2hex($iv) ?>
</div>

<div class="caixa">
    <span class="rotulo">Texto cifrado (base64)</span>
    <?= $textoCifradoOpenssl ?>
</div>

<div class="caixa">
    <span class="rotulo">Texto decifrado (deve ser igual ao original)</span>
    <?= htmlspecialchars($textoDecifradoOpenssl) ?>
</div>

<!-- 5) SODIUM -->
<h2>5. Criptografia autenticada — Sodium (secretbox)</h2>
<p>Além de esconder o conteúdo, garante que qualquer alteração nos dados seja detectada.</p>

<?php if ($sodiumDisponivel): ?>
    <div class="caixa">
        <span class="rotulo">Texto cifrado (hexadecimal)</span>
        <?= paraHex($textoCifradoSodium) ?>
    </div>

    <div class="caixa">
        <span class="rotulo">Texto decifrado (deve ser igual ao original)</span>
        <?= $textoDecifradoSodium !== false
            ? htmlspecialchars($textoDecifradoSodium)
            : '<span class="erro">falha na verificação de integridade</span>' ?>
    </div>
<?php else: ?>
    <p class="erro">A extensão Sodium não está disponível neste ambiente PHP.</p>
<?php endif; ?>


</body>
</html>
