using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTnhom
{
    class PhanSo
    {
        int TuSo;
        int MauSo;

        public PhanSo() {
            this.TuSo = 0;
            this.MauSo = 0;
        }

        public PhanSo(int TuSo, int MauSo) {
            this.TuSo = TuSo;
            this.MauSo = MauSo;
        }

        public string Cong(PhanSo phanSo1, PhanSo phanSo2) {

            //trường hợp mẫu số bằng nhau vd: 1/2 và 1/2
            if (phanSo1.MauSo == phanSo2.MauSo)
            {
                //tính tổng từ số giữ lại phần mẫu số.
                int TongTuSo = phanSo1.TuSo + phanSo1.TuSo;
                int MauSo = phanSo1.MauSo;

                //trả kết quả về.
                return KetQuaPhepTinh(TongTuSo, MauSo);
            }
            else {
                //vd 2 phần số 1/2, 1/3 khác mẫu -> tìm bội số chung giữa 2 và 3
                int boiSoChung = BoiSoChung(phanSo1.MauSo, phanSo2.MauSo);

                //bội số chung giũa 1/2 và 1/3 là 6 
                //tử số phân số 1 nhân 3 (6/2 = 3)
                int boiso1 = boiSoChung / phanSo1.MauSo;
                //từ số phân số 2 nhân 2 (6 / 3 = 2)
                int boiso2 = boiSoChung / phanSo2.MauSo;

                //tính tổng từ số.
                int TongTuSo = ((phanSo1.TuSo * boiso1) + (phanSo2.TuSo * boiso2));

                //trả kết quả về vd 1/2 + 1/3 = 5/6 -> 5 là tổng tử số, 6 là bội số chung
                return KetQuaPhepTinh(TongTuSo, boiSoChung);
            }
        }

        public string Tru(PhanSo phanSo1, PhanSo phanSo2)
        {
            if (phanSo1.MauSo == phanSo2.MauSo)
            {
                int HieuTuSo = phanSo1.TuSo - phanSo1.TuSo;
                int MauSo = phanSo1.MauSo;

                return KetQuaPhepTinh(HieuTuSo, MauSo);
            }
            else {
                int boiSoChung = BoiSoChung(phanSo1.MauSo, phanSo2.MauSo);

                int boiso1 = boiSoChung / phanSo1.MauSo;
                int boiso2 = boiSoChung / phanSo2.MauSo;

                int HieuTuSo = (phanSo1.TuSo * boiso1) - (phanSo2.TuSo * boiso2);

                return KetQuaPhepTinh(HieuTuSo, boiSoChung);
            }
        }

        private string KetQuaPhepTinh(int KetQuaTuSo, int MauSo) {
            //nếu kết quả từ số ra = 0 thì trả về kết quả là 0
            //vd 1/2 - 1/2 = 0
            if (KetQuaTuSo == 0)
            {
                return "Ket qua: 0";
            }
            else
            {
                //nếu tử số bằng mẫu số thì trả kết quả về bằng 1. Vd 2/2 = 1
                if (KetQuaTuSo == MauSo)
                {
                    return "Ket qua: 1";
                }
                else {
                    //nếu từ số khác mẫu số thì trả kết quả về
                    string KetQua = string.Format("Ket qua: {0}/{1}", KetQuaTuSo, MauSo);
                    return KetQua;
                }
            }
        }

        public string Nhan(PhanSo phanSo1, PhanSo phanSo2)
        {
            int TuSo = phanSo1.TuSo * phanSo2.TuSo;
            int MaSo = phanSo1.MauSo * phanSo2.MauSo;

            return string.Format("Ket qua: {0}/{1}", TuSo, MaSo);
        }

        public string Chia(PhanSo phanSo1, PhanSo phanSo2)
        {
            int TuSo = phanSo1.TuSo * phanSo2.MauSo;
            int MaSo = phanSo2.TuSo * phanSo1.MauSo;

            return string.Format("Ket qua: {0}/{1}", TuSo, MaSo);
        }

        public string LuyThua(PhanSo phanSo1, PhanSo phanSo2, int Mu)
        {
            //lấy lũy thừa phần số 1.
            int LuyThuaTuSo1 = (int)Math.Pow(phanSo1.TuSo, Mu);
            int LuyThuaMauSo1 = (int)Math.Pow(phanSo1.MauSo, Mu);

            //lấy lũy thừa phần số 1.
            int LuyThuaTuSo2 = (int)Math.Pow(phanSo2.TuSo, Mu);
            int LuyThuaMauSo2 = (int)Math.Pow(phanSo2.MauSo, Mu);

            //hiển thị kết quả
            string KetQuaPhanSo1 = string.Format("Luy thua phan so 1: {0}/{1}", LuyThuaTuSo1, LuyThuaMauSo1);
            string KetQuaPhanSo2 = string.Format("Luy thua phan so 2: {0}/{1}", LuyThuaTuSo2, LuyThuaMauSo2);

            //kị tự \n là kí tự xuống dóng mới.
            return KetQuaPhanSo1 + "\n" + KetQuaPhanSo2;
        }

        public int BoiSoChung(int a, int b) {

            //bội chung nhỏ nhất nằm trong khoảng max(a, b) <= bcnn <= a*b
            //nên chỉ cần duyệt các giá trị trong khoảng [max(a,b), a*b]   
            for (int i = Math.Max(a, b); i <= (a * b); i++) {
                //giá trị đầu tiên chia hết cho cả a, b là bcnn của 2 số a và b
                if (i % a == 0 && i % b == 0) {
                    int bcnn = i;
                    return bcnn;
                }
            }
            return 0;
        }

        public int UocSoChung(int So1, int So2) {
            while (So1 != So2) {
                if (So1 > So2)
                {
                    So1 = So1 - So2;
                }
                else So2 = So2 - So1;
            }
            return So1;
        }

    }
}
