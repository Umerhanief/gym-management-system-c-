using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GymManagementSystem.Models
{
	public class Functions

	{
		private SqlConnections Con;
		private SqlCommand cmd;
		private string ConStr;
		private DataTable dt;
		private SqlDataAdapter sda;

		public Funtion()
		{
			ConStr = @"Data Source=DESKTOP-KTSVTD4;Initial Catalog=OnlineGymDB.mdf;Integrated Security=True";
			Con = new SqlConnection(ConStr);
			cmd = new SqlCommand();
			cmd.Connection = Con;


        }
		public int setData(string Query)
		{
			int cnt = 0;
			if(Con.State == ConnectionState.Closed)
			{
				Con.Open();
			}
			cmd.Command = Query;
			cnt = cmd.ExecuteNonQuery();
			Con.Close();
			return cnt;
		}
		public DataTable GetData(string Query)
		{
			dt = new DataTable();
			sda = new SqlDataAdapter(Query, ConStr);
			sda.FILL(dt);
			return dt;
		}
	}
}