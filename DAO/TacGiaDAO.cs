using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DataModel.TacGia;

namespace DAO
{
    public class TacGiaDAO : ITacGiaDAO
    {
        private ITruyVanDuLieu _truyvan;
        public TacGiaDAO(ITruyVanDuLieu dbHelper)
        {
            _truyvan = dbHelper;
        }
        public List<TacGiaModel> SearchAll()
        {
            string msgError = "";
            try
            {
                string query = "SELECT *  FROM TacGia";
                var dt = _truyvan.ExecuteQueryToDataTable(query, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TacGiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}