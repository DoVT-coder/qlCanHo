using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Lap5.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }
        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public int sqlInsertCanHo(CanHoModel canho)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into CanHo values(@MaCH, @TenCH)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaCH", canho.MaCH);
                cmd.Parameters.AddWithValue("TenCH", canho.TenCH);
                return cmd.ExecuteNonQuery();
            }
        }
        public int sqlUpdateSuaChua(int MaTB, int MaCH, int LanThu, string NgayBT, NV_BTModel b)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = @"UPDATE NV_BT
                            SET MaTB = @MaTB, MaCH = @MaCH, LanThu = @LanThu, NgayBT = @NgayBT
                            WHERE MaNV = @manv1 and MaTB = @matb1 and MaCH = @mach1 and LanThu = @lanthu1";
                SqlCommand cmd = new SqlCommand(str,conn);
                cmd.Parameters.AddWithValue("MaTB", MaTB);
                cmd.Parameters.AddWithValue("MaCH", MaCH);
                cmd.Parameters.AddWithValue("LanThu", LanThu);
                cmd.Parameters.AddWithValue("NgayBT", NgayBT);
                
                cmd.Parameters.AddWithValue("manv1", b.MaNV);
                cmd.Parameters.AddWithValue("matb1", b.MaTB);
                cmd.Parameters.AddWithValue("mach1", b.MaCH);
                cmd.Parameters.AddWithValue("lanthu1", b.LanThu);
                return cmd.ExecuteNonQuery();
            }
        }
        public int sqlXoaLanSua(int MaNV, int MaTB, int MaCH, int LanThu)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = @"delete 
                          from NV_BT
                          where MaNV = @MaNV and MaTB = @MaTB and MaCH = @MaCH and LanThu = @LanThu";
                SqlCommand cmd = new SqlCommand(str,conn);
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("MaTB", MaTB);
                cmd.Parameters.AddWithValue("MaCH", MaCH);
                cmd.Parameters.AddWithValue("LanThu", LanThu);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<object> sqlListByTimeNhanVien(int SoLan)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select nv.MaNV, nv.SoDT, count(*) AS SoLan
                                from NhanVien nv join NV_BT on nv.MaNV = nv_bt.MaNV 
                                group by nv.MaNV, nv.SoDT
                                having count(*) >= @SoLanInput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoLanInput", SoLan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaNV = reader["MaNV"].ToString(),
                            SoDT = reader["SoDT"].ToString(),
                            SoLan = Convert.ToInt32(reader["SoLan"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> sqlLietKet(int MaNV)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select * 
                               from NV_BT
                                where MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(str,conn);
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new
                        {
                            MaNV = reader["MaNV"],
                            MaTB = reader["MaTB"],
                            MaCH = reader["MaCH"],
                            LanThu = reader["LanThu"],
                            NgayBT = reader["NgayBT"].ToString()
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<NhanVienModel> sqlListNhanVien()
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new NhanVienModel()
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            SoDT = reader["SoDT"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString()
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        
    }
}
