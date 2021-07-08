using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Utils
{
    public class StringNormalizer
    {

        public static String normalize(String original)
        {
            String VN = "ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýđĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝĐ";
            String EN = "AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYD";
            StringBuilder original_builder = new StringBuilder(original);
            int length = original_builder.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < VN.Length; j++)
                {
                    if (original_builder[i] == VN[j])
                    {
                        original_builder[i] =  EN[j];
                    }
                }
            }
            string s = original_builder.ToString().ToUpper().Trim();
            original_builder.Clear();
            original_builder.Append(s);

            return original_builder.Replace("  ", " |").Replace("| ", "").Replace("|", "").ToString();
        }

        public static String dateNormalize(String original)
        {
            String normalizedDate = "";
            normalizedDate += original.Substring(8, 2) + '/';
            normalizedDate += original.Substring(5, 2) + '/';
            normalizedDate += original.Substring(0, 2) + ' ';
            normalizedDate += original.Substring(11, 5);

            return normalizedDate;
        }
    }


}
