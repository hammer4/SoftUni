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
class Student
{
    protected $name;
    protected $age;
    protected $grade;

    function __construct($name, $age, $grade)
    {
        $this->name = $name;
        $this->age = $age;
        $this->grade = $grade;
    }

    public function __toString()
    {
        return "<ul><li>Name: $this->name</li><li>Age: $this->age</li><li>Grade: $this->grade</li></ul>";
    }
}

if(isset($_GET['input']) && isset($_GET['delimiter'])) {
    $students = [];
    $lines = explode("\n", $_GET['input']);
    $lines = array_map('trim', $lines);
    $delimiter = $_GET['delimiter'];

    foreach ($lines as $line) {
        $tokens = explode($delimiter, $line);
        $name = $tokens[0];
        $age = intval($tokens[1]);
        $grade = floatval($tokens[2]);
        $students[] = new Student($name, $age, $grade);
    }

    foreach ($students as $student) {
        echo $student;
    }
}