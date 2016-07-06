<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="key-value-pairs"></textarea>
    Target Key: <input type="text" name="target-key">
    <input type="submit">
</form>
</body>
</html>

<?php
$arr = [];
if(isset($_GET['delimiter']) && isset($_GET['key-value-pairs']) && isset($_GET['target-key'])) {
    $delimiter = $_GET['delimiter'];
    $pairs = explode("\n", $_GET['key-value-pairs']);
    $pairs = array_map('trim', $pairs);
    foreach ($pairs as $pair) {
        $tokens = explode($delimiter, $pair);
        if(isset($arr[$tokens[0]])) {
            $arr[$tokens[0]][] = $tokens[1] ;
        } else {
            $innerArr = [];
            $innerArr[] = $tokens[1];
            $arr[$tokens[0]] = $innerArr;
        }
    }

    if(isset($arr[$_GET['target-key']])) {
        echo implode("<br>", $arr[$_GET['target-key']]);
    } else {
        echo "None";
    }
}
?>