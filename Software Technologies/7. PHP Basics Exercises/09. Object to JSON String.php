<html>
<head>

</head>
<body>
<form>
    Input:
    <br>
    <textarea name="input"></textarea>
    <br>
    Delimiter:
    <br>
    <input type="text" name="delimiter">
    <br>
    <input type="submit">
</form>
</body>
</html>

<?php
$object = new stdClass();
if(isset($_GET['input']) && isset($_GET['delimiter'])) {
    $lines = explode("\n", $_GET['input']);
    $lines = array_map('trim', $lines);
    $delimiter = $_GET['delimiter'];

    foreach ($lines as $line) {
        $tokens = explode($delimiter, $line);
        $object = (array)$object;
        if(is_numeric($tokens[1])) {
            $object[$tokens[0]] = floatval($tokens[1]);
        } else {
            $object[$tokens[0]] = $tokens[1];
        }
        $object = (object)$object;
    }

    echo json_encode($object, JSON_UNESCAPED_SLASHES);
}