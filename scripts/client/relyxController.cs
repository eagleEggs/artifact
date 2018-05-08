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

    [SerializeField] private Text connectionText;
    [SerializeField] private InputField tableText;
    [SerializeField] private InputField columnText;
    [SerializeField] private InputField valueText;

    [SerializeField] private Material connectionStatus;
    [SerializeField] private String serverName;
    [SerializeField] private String DBUserID;
    [SerializeField] private String DBPassword;
    [SerializeField] private String DBName;
    [SerializeField] private Button commit;
    [SerializeField] private Button connect;
    [SerializeField] private Button clear;


    // Use this for initialization
    void Start()
    {

        //init buttons:

        // commit:
        Button commitButton = commit.GetComponent<Button>();
        commitButton.onClick.AddListener(Commit);

        // connect:
        Button connectButton = connect.GetComponent<Button>();
        connectButton.onClick.AddListener(Connect);

        // clear:
        Button clearButton = clear.GetComponent<Button>();
        clearButton.onClick.AddListener(Clear);


        // init getComponents:

        connectionStatus.SetColor("_Color", Color.red);
        connectionText.text = "Not Connected :(";


    }


    void Connect(){

        connString = // the string that logs into the db
            "server="+serverName+";" +
            "uid="+DBUserID+";" +
            "Password="+DBPassword+";" +
            "Database="+DBName+";" +
            "Allow User Variables = True";

        db2 = new MySql.Data.MySqlClient.MySqlConnection(connString); // connect with the above string

        try
        {
            db2.Open(); // open the db connection
            connectionStatus.SetColor("_Color", Color.green);
            connectionText.text = "Connected!!! :D";
        }
            catch
            {
               Debug.Log("Cannot connect");
               connectionStatus.SetColor("_Color", Color.blue);

            }


    }


    void Commit(){

        // set vars:
        tableNameFieldString = tableNameField.text;
        columnNameFieldString = columnNameField.text;
        valueFieldString = valueField.text;

        //execute commands:
        MySql.Data.MySqlClient.MySqlCommand command = db2.CreateCommand();


        // check for table and column first, add if not exist
        try
        {
            // check/add table
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +tableNameFieldString + " (`ID` int(11) NOT NULL AUTO_INCREMENT,`date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,PRIMARY KEY(`ID`,`date`)) ENGINE = InnoDB AUTO_INCREMENT = 32 DEFAULT CHARSET = latin1";
            command.ExecuteNonQuery();

            // check/add column
            command.CommandText = "ALTER TABLE "+tableNameFieldString+" ADD COLUMN IF NOT EXISTS " + columnNameFieldString + " int(11)"; // column check/add
            command.ExecuteNonQuery();

        }

        catch
        {

            connectionText.text = "Create Issue :3";
       
        }

        // after checking for add, commit:
        try
        {
            command.CommandText = "insert into " + tableNameFieldString + "(" + columnNameFieldString + ") values(" + valueFieldString + ")";
            command.ExecuteNonQuery();
            connectionText.text = "You Committed >.<"; 

        }

            catch{

            connectionText.text = "Check Input :/";         

                 }



    }

    void Clear(){

        tableText.text = "";
        columnText.text = "";
        valueText.text = "";


    }



}