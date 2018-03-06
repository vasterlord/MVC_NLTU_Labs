using NLTU_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NLTU_Labs.Data
{
    public class ConvertRepository
    {
        public List<string> GetOptions()
        {
            return Data.Options.ToList();
        } 

        public void convertToBinary(ConvertValue convertValue)
        {
            int value = Convert.ToInt32(convertValue.Value);
            convertValue.Result = Convert.ToString(value, 2);
        }

        public void convertToOct(ConvertValue convertValue)
        {
            int value = Convert.ToInt32(convertValue.Value);
            convertValue.Result = Convert.ToString(value, 8).ToUpper();
        } 

        public void convertFromOct(ConvertValue convertValue)
        {
            convertValue.Result = Convert.ToInt32(convertValue.Value, 8).ToString();
        } 

        public void convertFromBinary(ConvertValue convertValue)
        {
            convertValue.Result = Convert.ToInt32(convertValue.Value, 2).ToString();
        }
        public void convertToHex(ConvertValue convertValue)
        {
            int value = Convert.ToInt32(convertValue.Value);
            convertValue.Result = Convert.ToString(value, 16).ToUpper();
        }
        public void convertFromHex(ConvertValue convertValue)
        {
            convertValue.Result = Convert.ToInt32(convertValue.Value, 16).ToString();
        }

        public void SelectConveringType(ConvertValue convertValue, string option)
        {
            string errorMessage = string.Empty;
            try
            {
                switch (option)
                {
                    case "Decimal to binary":
                        errorMessage = "Invalid entered value for converting decimal to binary!";
                        convertToBinary(convertValue);
                        break;
                    case "Decimal to octal":
                        errorMessage = "Invalid entered value for converting decimal to octal!";
                        convertToOct(convertValue);
                        break;
                    case "Decimal to hexadecimal":
                        errorMessage = "Invalid entered value for converting decimal to hexadecimal!";
                        convertToHex(convertValue);
                        break;
                    case "Binary to decimal":
                        errorMessage = "Invalid entered value for converting binary to decimal!";
                        convertFromBinary(convertValue);
                        break;
                    case "Octal to decimal":
                        errorMessage = "Invalid entered value for converting octal to decimal!";
                        convertFromOct(convertValue);
                        break;
                    case "Hexadecimal to decimal":
                        errorMessage = "Invalid entered value for converting hexadecimal to decimal!";
                        convertFromHex(convertValue);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw new Exception(errorMessage); 
            }
        }
    }
}