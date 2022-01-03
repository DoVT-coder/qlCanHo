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
        public void sqlInsertCanHo(CanHoModel canho)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into CanHo values(@MaCH, @TenCH)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaCH", canho.MaCH);
                cmd.Parameters.AddWithValue("TenCH", canho.TenCH);
                cmd.ExecuteNonQuery();
            }
        }
        public void sqlUpdateSuaChua(int MaNV, int MaTBC, int MaCHC, int LanThuC, int MaTB, int MaCH, int LanThu, string NgayBT)
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
                cmd.Parameters.AddWithValue("manv1", MaNV);
                cmd.Parameters.AddWithValue("matb1", MaTBC);
                cmd.Parameters.AddWithValue("mach1", MaCHC);
                cmd.Parameters.AddWithValue("lanthu1", LanThuC);
                cmd.ExecuteNonQuery();
            }
        }
        public void sqlXoaLanSua(int MaNV, int MaTB, int MaCH, int LanThu)
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
                cmd.ExecuteNonQuery();
            }
        }
        public List<NhanVienLietKeModel> sqlListByTimeNhanVien(int SoLan)
        {
            List<NhanVienLietKeModel> list = new List<NhanVienLietKeModel>();
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
                        list.Add(new NhanVienLietKeModel()
                        {
                            TenNV = reader["MaNV"].ToString(),
                            SoDT = reader["SoDT"].ToString(),
                            SoLanSua = Convert.ToInt32(reader["SoLan"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<NV_BTModel> sqlLietKet(int MaNV)
        {
            List<NV_BTModel> list = new List<NV_BTModel>();
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
                        list.Add(new NV_BTModel()
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            MaTB = Convert.ToInt32(reader["MaTB"]),
                            MaCH = Convert.ToInt32(reader["MaCH"]),
                            LanThu = Convert.ToInt32(reader["LanThu"]),
                            NgayBT = Convert.ToDateTime(reader["NgayBT"])
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
