using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaiThuatToan_12_11_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Ptb2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SolveQuadratic(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (a == 0)
            {
                // Xử lý phương trình bậc 1
                if (b != 0)
                {
                    double root = -c / b;
                    ViewBag.Result = $"Phương trình có một nghiệm: x = {root}";
                }
                else if (c == 0)
                {
                    ViewBag.Result = "Phương trình có vô số nghiệm";
                }
                else
                {
                    ViewBag.Result = "Phương trình vô nghiệm";
                }
            }
            else
            {
                if (delta > 0)
                {
                    double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

                    ViewBag.Result = $"Phương trình có hai nghiệm phân biệt: x1 = {root1}, x2 = {root2}";
                }
                else if (delta == 0)
                {
                    double root = -b / (2 * a);
                    ViewBag.Result = $"Phương trình có nghiệm kép: x1 = x2  = {root}";
                }
                else
                {
                    ViewBag.Result = "Phương trình vô nghiệm.";
                }
            }

            return View("Show");
        }




        public ActionResult Sapxep()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SortNumbers(string numberList)
        {
            List<int> numbers = ParseNumberList(numberList);

            // Sắp xếp theo chiều tăng dần
            List<int> ascendingOrder = numbers.OrderBy(n => n).ToList();

            // Sắp xếp theo chiều giảm dần
            List<int> descendingOrder = numbers.OrderByDescending(n => n).ToList();

            ViewBag.AscendingOrder = ascendingOrder;
            ViewBag.DescendingOrder = descendingOrder;

            return View("Show");
        }
        private List<int> ParseNumberList(string input)
        {
            return input.Split(',').Select(int.Parse).ToList();
        }


        public ActionResult DocSo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReadNumber(int inputNumber)
        {
            string numberInWords = NumberToWords(inputNumber);
            ViewBag.NumberInWords = numberInWords;
            return View("Show");
        }

        private string NumberToWords(int number)
        {
           
            if (number < 0 || number > 999)
            {
                return "Không hỗ trợ";
            }

            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] teens = { "", "mười", "mười một", "mười hai", "mười ba", "mười bốn", "mười lăm", "mười sáu", "mười bảy", "mười tám", "mười chín" };
            string[] tens = { "", "", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

            string result = "";

            int hundreds = number / 100;
            int remainder = number % 100;

            if (hundreds > 0)
            {
                result += units[hundreds] + " trăm ";
            }

            if (remainder > 0)
            {
                if (remainder < 10)
                {
                    result += units[remainder];
                }
                else if (remainder < 20)
                {
                    result += teens[remainder - 10];
                }
                else
                {
                    int tensDigit = remainder / 10;
                    int onesDigit = remainder % 10;
                    result += tens[tensDigit] + " " + units[onesDigit];
                }
            }

            return result;
        }








    }
}