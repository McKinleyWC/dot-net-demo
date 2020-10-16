using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace DAL
{
    public class SqlUtils
    {
        public static void InsertValuesToDB(AnnualProdReport theReports)
        {

            using (var connection = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "DELETE FROM [dot_net_angular_demo].dbo.Fields; DELETE FROM [dot_net_angular_demo].dbo.Records; " +
                    "DELETE FROM [dot_net_angular_demo].dbo._Links; DELETE FROM [dot_net_angular_demo].dbo.Results; ";
                connection.Execute(query);

                query = "INSERT INTO [dot_net_angular_demo].dbo.Results VALUES (@resource_id, @limit, @total)";
                connection.Execute(query, theReports.result);

                query = "INSERT INTO [dot_net_angular_demo].dbo.Fields VALUES (@ResultId, @type, @id)";
                connection.Execute(query, theReports.result.fields);

                query = "INSERT INTO [dot_net_angular_demo].dbo.Records VALUES (@ResultId, @_id, @_5Bills, @_50Bills, @_1Bills, @_10Bills, @_100Bills, @_2Bills, @_20Bills, @FiscalYear)";
                connection.Execute(query, theReports.result.records);

                query = "INSERT INTO [dot_net_angular_demo].dbo._Links VALUES (@ResultId, @start, @next)";
                connection.Execute(query, theReports.result._links);
            }
        }

        public static Result[] GetResults()
        {
            Result[] results = { };

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Results";
                results = conn.Query<Result>(query).ToArray();
            }

            return results;
        }

        public static Result GetResults(string id)
        {
            Result results = new Result();

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Results WHERE resource_id = @id";
                var param = new DynamicParameters();
                param.Add("@id", id);

                results = conn.Query<Result>(query, param).FirstOrDefault();
            }

            return results;
        }

        public static List<Field> GetFields(string resultId)
        {
            List<Field> fields;

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Fields WHERE ResultId = @ResultId";
                DynamicParameters param = new DynamicParameters();
                param.Add("@ResultId", resultId);
                fields = conn.Query<Field>(query, param).ToList();
            }

            return fields;
        }

        public static Field GetFields(string resultId, string fieldId)
        {
            Field field = new Field();

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Fields WHERE ResultId = @ResultId AND id = @id";
                var param = new DynamicParameters();
                param.Add("@ResultId", resultId);
                param.Add("@id", fieldId);

                field = conn.Query<Field>(query, param).SingleOrDefault();
            }

            return field;
        }

        public static List<Record> GetRecords(string resultId)
        {
            List<Record> records;

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Records WHERE ResultId = @ResultId";
                var param = new DynamicParameters();
                param.Add("@ResultId", resultId);

                records = conn.Query<Record>(query, param).ToList();
            }

            return records;
        }

        public static Record GetRecords(string resultId, string recordId)
        {
            Record record = new Record();

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Records WHERE ResultId = @ResultId AND _id = @id";
                var param = new DynamicParameters();
                param.Add("@ResultId", resultId);
                param.Add("@id", recordId);

                record = conn.Query<Record>(query, param).SingleOrDefault();
            }

            return record;
        }

        public static _Links GetLinks(string resultId)
        {
            _Links links;

            using (var conn = new SqlConnection(@"Data Source=Will-PC;Trusted_Connection = True;User Id=Will-PC\beswe_000;"))
            {
                var query = "SELECT * FROM [dot_net_angular_demo].dbo.Fields WHERE ResultId = @ResultId";
                var param = new DynamicParameters();
                param.Add("@ResultId", resultId);

                links = conn.Query<_Links>(query, param).FirstOrDefault();
            }

            return links;
        }
    }
}
