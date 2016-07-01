<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<!--Write your PHP Script here-->
<?php
if(isset($_GET['num'])) {
    $num = intval($_GET['num']);
    if($num == 1) {
        echo 1;
    } else if($num == 2) {
        echo 1 . " " . 1 . " ";
    } else {
        echo 1 . " " . 1 . " ";

        $a = 1;
        $b = 1;

        for($i = 2; $i <$num; $i++) {
            $c = $a + $b;
            $a = $b;
            $b = $c;
            echo $c . " ";
        }
    }
}
?>
</body>
</html>