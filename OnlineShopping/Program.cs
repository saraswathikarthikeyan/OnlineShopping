using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OnlineShopping
{
    public class Program
    {
        public static int GetMaxValueProducts(int budget, DataTable dtProduct)
        {
            int toatlValue = 0;
            int costSpent = 0;
            string productsList = "";
            string productNames = "";

            try
            {
                List<string> arrSubsetIds = new List<string>();
                DataView dv = dtProduct.DefaultView;
                dv.Sort = "Id asc";

                DataTable sortedDT = dv.ToTable();

                //Fetches the Product Ids and keep in an array
                int[] arrIds = sortedDT.AsEnumerable().Select(s => s.Field<int>("Id")).ToArray<int>();

                /* * Code Fetches the Subset of the ProductIDs : Starts*/
                List<string> arrList = new List<string>();
                for (int i = 0; i < Math.Pow(2, arrIds.Length); i++){
                    string combineIds = "";
                    for (int j = 0; j < arrIds.Length; j++){
                        if ((i & (1 << (arrIds.Length - j - 1))) != 0) {
                            if (combineIds != "")  {
                                combineIds = combineIds + "," + arrIds[j].ToString();
                            }
                            else {
                                combineIds = arrIds[j].ToString();
                            }
                        }
                    }
                    arrList.Add(combineIds);
                }
                /* * Code Fetches the Subset of the ProductIDs : Ends*/

                /* Iterates through the subset Ids in the Dataset and Calcualtes Max Value - Starts */
                Dictionary<string, int> dictProduct = new Dictionary<string, int>();
                foreach (var str in arrList) {                    
                    int totValue = 0;
                    int totCost = 0;
                    if (str != "") {

                        //Calculate the sum of total value and Cost for all subset of Ids
                        DataRow[] results = sortedDT.Select("Id IN(" + str + ")");
                        foreach (DataRow row in results) {
                            if ((totCost + row.Field<int>("Price")) <= budget) {
                                totValue = totValue + row.Field<int>("value");
                                totCost = totCost + row.Field<int>("Price");
                            }
                        }
                    }
                    //Stores the Maximum Value for the different combination of ProductIds
                    if (!dictProduct.ContainsValue(totValue)) {
                        dictProduct.Add(str, totValue);
                    }
                }
                /* Iterates through the subset Ids in the Dataset and Calcualtes Max Value - Ends */

                //Sort the Dictionary in Descending Order and Fetches the Maximum Value Product Purchase
                var maxValue = dictProduct.OrderByDescending(i => i.Value).First();
                toatlValue = maxValue.Value;
                productsList = maxValue.Key;

                /* Code to Display the Result: Product Name: Value: CostSpent - Starts */
                DataRow[] productRow = sortedDT.Select("Id IN(" + productsList + ")");
                foreach (DataRow row in productRow) {
                    if (productNames == ""){
                        productNames = row.Field<string>("ProductName");
                    }
                    else {
                        productNames = productNames + "," + row.Field<string>("ProductName");
                    }
                    costSpent = costSpent + row.Field<int>("Price");
                }
                Console.WriteLine("Maximum Value: {0}", toatlValue);
                Console.WriteLine("Product List: {0}", productNames);
                Console.WriteLine("Cost Spent: {0}", costSpent);
                /* Code to Display the Result: Product Name: Value: CostSpent - Ends */

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            return toatlValue;
        }
        public static void Main(string[] args)
        {
            try
            {
                //Prompt the user to enter the Budget
                Console.WriteLine("Enter your budget");
                string strBudget = Console.ReadLine();
                int budget = Convert.ToInt32(strBudget);

                //Prompt the user to enter the Number of Product
                Console.WriteLine("Enter the number of products");
                string strproductCount = Console.ReadLine();
                int numOfProducts = Convert.ToInt32(strproductCount);

                //Create the Table Columns to add the Product Details
                DataTable dtProduct = new DataTable();
                dtProduct.Columns.Add("Id", typeof(int));
                dtProduct.Columns.Add("ProductName", typeof(string));
                dtProduct.Columns.Add("Price", typeof(int));
                dtProduct.Columns.Add("Value", typeof(int));

                Console.WriteLine("Enter the Product Details");
                Console.WriteLine("Example: Product1 20 100");

                //Iterate through the number of products to store the product details
                for (int i = 1; i <= numOfProducts; i++) {
                    string[] productList = Console.ReadLine().Split(' ');
                    dtProduct.Rows.Add(i, Convert.ToString(productList[0]), Convert.ToInt32(productList[1]), Convert.ToInt32(productList[2]));
                }

                //Calls method to Get the Maximum Value of Products user can buy with budget.
                int totValue = GetMaxValueProducts(budget, dtProduct);
                Console.ReadLine();
            }
            catch (Exception ex){
                Console.WriteLine(" {0} - Something went wrong! check your input!", ex.Message);
                Console.ReadLine();
            }
        }

       
    }
}
