<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sums by Town</title>
</head>
<body>
<?php
function calcSumsByTown(array $townIncomes) :array
{
    $sums = [];
    foreach ($townIncomes as $townIncome) {
        $tokens = explode(':', $townIncome);
        $town = $tokens[0];
        $income = $tokens[1];
        if(isset($sums[$town])) {
            $sums[$town] += $income;
        } else {
            $sums[$town] = $income;
        }
    }

    ksort($sums);
    return $sums;
}

if(isset($_GET['towns-incomes'])) {
    $townIncomes = array_map('trim', explode("\n", $_GET['towns-incomes']));
    $sumsByTown = calcSumsByTown($townIncomes);
    foreach ($sumsByTown as $town => $sum) {
        echo $town . " -> " . $sum . "<br>\n";
    }
}
?>

<form>
    <textarea rows="10" name="towns-incomes"></textarea><br>
    <input type="submit" value="Calculate">
</form>
</body>
</html>