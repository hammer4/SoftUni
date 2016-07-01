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
    $num = $_GET['num'];
    $factorial = 1;

    for($i = 2; $i <= $num; $i++) {
        $factorial *= $i;
    }

    echo $factorial;
}
?>
</body>
</html>