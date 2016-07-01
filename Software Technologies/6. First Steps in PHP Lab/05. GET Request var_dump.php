<!DOCTYPE html>
<html>
<head>
    <title>GET Request var_dump</title>
</head>
<body>
<form>
    <div>Name:</div><input type="text" name="personName" />
    <div>Age:</div><input type="number" name="age" />
    <div>Town:</div>
    <select name="townId">
        <option value="10">Sofia</option>
        <option value="20">Varna</option>
        <option value="30">Plovdiv</option>
    </select>
    <div><input type="submit" /></div>
</form>
<?php var_dump($_GET); ?>
</body>
</html>