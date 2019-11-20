using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
	private string connectionString;

	private List<Assignment> assignments = new List<Assignment>();

	private DateTime tmpDate;

	[SerializeField]
	private GameObject assignmentPrefab;
	[SerializeField]
	private GameObject datePrefab;

	// Use this for initialization
	void Start ()
	{
		connectionString = "URI=file:" + Application.dataPath + "/AssignmentDatabase.s3db"; //Path to database.
		GetAssignments();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void CreateAssignment(string name, DateTime dueDate, bool repeatable, int red, int green, int blue, string notes, DateTime alarmTime)
	{
		using (IDbConnection dbConnection = new SqliteConnection (connectionString))
		{
			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand ())
			{
				string sqlQuery = String.Format ("INSERT INTO Assignments(Name, Date, Repeatable, Red, Green, Blue, Notes, Alarm) VALUES(\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")",name,dueDate,repeatable,red,green,blue,notes,alarmTime);

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();
			}
		}
	}

	private void GetAssignments()
	{
		assignments.Clear ();

		using (IDbConnection dbConnection = new SqliteConnection (connectionString))
		{
			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand ())
			{
				string sqlQuery = "SELECT * FROM Assignments ORDER BY DATE DESC";

				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader())
				{
//					int id = reader.GetOrdinal ("IDNumber");
//					int name = reader.GetOrdinal ("Name");
//					int date = reader.GetOrdinal ("Date");
//					int rep = reader.GetOrdinal ("Repeatable");
//					int red = reader.GetOrdinal ("Red");
//					int green = reader.GetOrdinal ("Green");
//					int blue = reader.GetOrdinal ("Blue");
//					int note = reader.GetOrdinal ("Notes");
//					int alarm = reader.GetOrdinal ("Alarm");
//
//					Debug.Log (id + " " + name + " " + date + " " + rep + " " + red + " " + green + " " + blue + " " + note + " " + alarm);

					while (reader.Read ())
					{
						assignments.Add (new Assignment (Convert.ToInt32(reader["IDNumber"]), Convert.ToString(reader["Name"]), Convert.ToDateTime(reader["Date"]), Convert.ToBoolean(reader["Repeatable"]), Convert.ToInt32(reader["Red"]), Convert.ToInt32(reader["Green"]), Convert.ToInt32(reader["Blue"]), Convert.ToString(reader["Notes"]), Convert.ToDateTime(reader["Alarm"])));
					}

					Debug.Log (assignments[0].ID + " " + assignments[0].Name + " " + assignments[0].Date + " " + assignments[0].Repeat + " " + assignments[0].Red + " " + assignments[0].Green + " " + assignments[0].Blue + " " + assignments[0].Notes + " " + assignments[0].AlarmTime);

					dbConnection.Close ();
					reader.Close ();
				}
			}
		}
	}

	private void DeleteAssignment(int id)
	{
		using (IDbConnection dbConnection = new SqliteConnection (connectionString))
		{
			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand ())
			{
				string sqlQuery = String.Format ("DELETE FROM Assignments WHERE AssignmentID = \"{0}\"",id);

				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar ();
				dbConnection.Close ();
			}
		}
	}

	public void ShowAssignments()
	{
		for (int i = 0; i < assignments.Count; i++)
		{
			if (tmpDate != assignments[i].Date)
			{
				GameObject tmpDateObject = Instantiate (datePrefab);
				tmpDateObject.GetComponent<Text> ().text = assignments[i].Date.ToString ("yyyy MMMMM dd");
				tmpDate = assignments[i].Date;
			}

			GameObject tmpObject = Instantiate (assignmentPrefab);

			Assignment tmpAssignment = assignments[i];

			tmpObject.GetComponent<AssignmentScript> ().SetAssignment (tmpAssignment.Name);
		}
	}
}