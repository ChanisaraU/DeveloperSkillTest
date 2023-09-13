/*  ######################################## CHALLENGE!!! ########################################  /*

Jack กับ Jill เป็นเพื่ิอนกัน พวกเขาชอบไปทานอาหารญี่ปุ่นด้วยกันมาก พวกเขาจะนำเงินมารวมกัน
และจะจ่ายเงินที่รวมกันทั้งหมด เพื่อเลือกเมนู 2 เมนู ที่ต่างกันเสมอมารับประทาน
จงช่วยพวกเขาเลือกเมนูอาหาร 2 เมนู ตามงบประมาณที่มีด้วย function

>>> List<int> MenusFromBudget(int m, List<int> arr) <<<

โดยที่:
m = เงินที่รวมกันทั้งหมด
arr = Array ของ menu อาหาร ซื่งค่าตัวเลข (integer) แต่ละค่าใน array คือ ราคาอาหาร และ index ของ array คือ ชนิดอาหาร (menu) และเป็น 1-based indexing

Function Return = Array ผลลัพธ์ ของชนิดอาหารที่เลือกไว้ 2 ชนิด

ตัวอย่าง:
m = 4
arr = [2, 3, 5, 2, 3] คือ
ราคาอาหาร   |   ชนิดอาหาร
    2       |      1
    3       |      2
    5       |      3
    2       |      4
    3       |      5

ดังนั้น: 
Function Return = [1, 4]

------------------------------------------------------------------------------------------------
ข้อจำกัด:
m มีค่าได้ตั้งแต่ 2 to 10^4
menus มีจำนวนได้ตั้งแต่ 1 to N และค่าตัวเลขใน menus array มีค่าได้ตั้งแต่ 1 to 10^4
------------------------------------------------------------------------------------------------

จงแก้ไขฟังก์ชัน List<int> MenusFromBudget(int m, List<int> arr) ให้ทำงานได้ตามผลลัพธ์ที่ต้องการ

/*  ############################################################################################  */

namespace Challenge.Service
{
    public class App
    {
        public static List<int> MenusFromBudget(int foot, List<int> arr)
        {
            Dictionary<int, List<int>> menuPrices = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int menuPrice = arr[i];

                if (menuPrices.ContainsKey(menuPrice))
                {
                    menuPrices[menuPrice].Add(i + 1);
                }
                else
                {
                    menuPrices[menuPrice] = new List<int> { i + 1 };
                }
            }

            foreach (var items in menuPrices)
            {
                int menuPrice = items.Key;
                int remainingBudget = foot - menuPrice;

                if (menuPrices.ContainsKey(remainingBudget) && remainingBudget != menuPrice)
                {
                    result.Add(items.Value.First());
                    result.Add(menuPrices[remainingBudget].First());
                    return result;
                }
                else if (remainingBudget == menuPrice && items.Value.Count >= 2)
                {
                    result.Add(items.Value.First());
                    result.Add(items.Value[1]);
                    return result;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var m = 4;
            var arr = new List<int>() { 2, 3, 5, 2, 3 };
            var expected = new List<int>() { 1, 4 };
            var result = MenusFromBudget(m, arr);
            if (!result.SequenceEqual(expected))
            {
                Console.WriteLine("Fail -> output: [{0}], expected: [{1}]", string.Join(", ", result), string.Join(", ", expected));
            }
            else
            {
                Console.WriteLine("Success");
            }

        }
    }
}

