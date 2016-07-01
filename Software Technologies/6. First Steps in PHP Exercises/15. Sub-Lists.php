<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1" />
    M: <input type="text" name="num2" />
    <input type="submit" />
</form>
    <!--Write your PHP Script here-->
    <?php
    if(isset($_GET['num1']) && isset($_GET['num2'])) {
        $num1 = intval($_GET['num1']);
        $num2 = intval($_GET['num2']);

        echo "<ul>";

        for($i = 1; $i <= $num1; $i++) {
            echo "\t<li>List $i\n\t\t<ul>\n";

            for($j=1; $j <= $num2; $j++) {
                echo "\t\t\t<li>\n\t\t\t\tElement $i.$j\n\t\t\t</li>\n";
            }

            echo "\t\t</ul>\n\t</li>";
        }
    }
    ?>
</ul>
</body>
</html>