<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        table * {
            border: 1px solid black;
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <!--Write your PHP Script here-->
    <?php
    for($i=51; $i <= 255; $i+=51) {
        echo "<tr><td style='background-color: rgb($i, 0, 0)'></td><td style='background-color: rgb(0, $i, 0)'></td><td style='background-color: rgb(0, 0, $i)'></td></tr>";
    }
    ?>
</table>
</body>
</html>