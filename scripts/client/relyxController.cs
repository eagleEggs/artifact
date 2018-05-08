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

    [SerializeField] Text connectionText;

    [SerializeField] private Material connectionStatus;
    [SerializeField] private String serverName;
    [SerializeField] private String DBUserID;
    [SerializeField] private String DBPassword;
    [SerializeField] private String DBName;

    [SerializeField] private Button commit;
    [SerializeField] private Button connect;


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



}