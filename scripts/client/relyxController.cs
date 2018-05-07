using UnityEngine;
using MySql;
using System;
using UnityEngine.UI;


public class relyxController : MonoBehaviour
{


    private string connString;
    private MySql.Data.MySqlClient.MySqlConnection db2;
    public InputField tableNameField;
    public InputField columnNameField;
    public InputField valueField;
    private String tableNameFieldString;
    private String columnNameFieldString;
    private String valueFieldString;
    [SerializeField] private Button commit;


    // Use this for initialization
    void Start()
    {

        connString = // the string that logs into the db
            "server=SERVERNAME;" +
            "uid=USERID;" +
            "Password=PASSWORD;" +
            "Database=DBNAME;" +
            "Allow User Variables = True";

        db2 = new MySql.Data.MySqlClient.MySqlConnection(connString); // connect with the above string
        db2.Open(); // open the db connection

        //init buttons:
        Button commitButton = commit.GetComponent<Button>();
        commitButton.onClick.AddListener(Commit);



    }

    void Commit(){

        // set vars:
        tableNameFieldString = tableNameField.text;
        columnNameFieldString = columnNameField.text;
        valueFieldString = valueField.text;

        //execute commands:
        MySql.Data.MySqlClient.MySqlCommand command = db2.CreateCommand();

        command.CommandText = "insert into "+tableNameFieldString+"("+columnNameFieldString+") values("+valueFieldString+")";
        command.ExecuteNonQuery();




    }



}