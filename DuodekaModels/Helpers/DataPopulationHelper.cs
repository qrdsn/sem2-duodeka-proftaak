using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuodekaModels.Helpers
{
    public static class DataPopulationHelper
    {
        /// <summary>
        /// Get a value from db that can be null in the db and the c# type allows null ( : class)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <param name="colname"></param>
        /// <returns></returns>
        public static T GetNullableValue<T>(this SqlDataReader rdr, string colname)
            where T : class
        {
            int colpos = rdr.GetOrdinal(colname);

            if (!rdr.IsDBNull(colpos))
            {
                return rdr.GetFieldValue<T>(colpos);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get a value from the db that can never! be null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <param name="colname"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static T GetNonNullableValue<T>(this SqlDataReader rdr, string colname)
        {
            int colpos = rdr.GetOrdinal(colname);

            if (!rdr.IsDBNull(colpos))
            {
                return rdr.GetFieldValue<T>(colpos);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Get a c# non nullable from db and return null if db is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <param name="colname"></param>
        /// <returns></returns>
        public static Nullable<T> GetNullableStruct<T>(this SqlDataReader rdr, string colname) 
            where T : struct
        {
            int colpos = rdr.GetOrdinal(colname);

            if (!rdr.IsDBNull(colpos))
            {
                return rdr.GetFieldValue<T>(colpos);
            }
            else
            {
                return null;
            }
        }
    }
}
