<?php


if(isset ($_REQUEST['table']))
{
$tables = $_REQUEST['table'];
}
if(isset ($_REQUEST['column']))
{
$columns = $_REQUEST['column'];
}

$paramJoin = $tables . ' ' . $columns;

$file = 'table.txt';
$fileC = $tables;
file_put_contents($file, $fileC);

$file2 = 'column.txt';
$file2C = $columns;
file_put_contents($file2, $file2C);


$test = shell_exec("sudo python pyServer.py");
print $test;



?>
