using System.Linq;
using System.Collections.Generic;
using System;

namespace Bank
{
    public class Account
    {
        public double AccountBallance { get; set; }
        public enum CurrencySymbol { EUR, GBP, USD}
        CurrencyService currencyService = new CurrencyService();
        
        public Account(double accountBallance)
        {
            AccountBallance = accountBallance;
        }
        
        public double MakeTransfer(double transferValue, CurrencySymbol currencySymbol){                                    
            
            if (this.AccountBallance < transferValue) throw new ArgumentException("Not enough money");          

            this.AccountBallance = this.AccountBallance - CalculateTransferValue(currencySymbol, transferValue);

            if (this.AccountBallance < -200) throw new ArgumentOutOfRangeException("Debet");
                 
            return this.AccountBallance;
        }
        public double CalculateTransferValue(CurrencySymbol currencySymbol, double transferValue){
            var value = ConvertExchangeValue(currencySymbol);
            double correctTransferValue = value * transferValue;
            return correctTransferValue;
        }
        private double ConvertExchangeValue(CurrencySymbol currencySymbol){
            var something = CheckCurrencySymbol(currencySymbol);
            double value = something.Count();
            return value;
        }
        private IEnumerable<double> CheckCurrencySymbol(CurrencySymbol currencySymbol){
            if (currencySymbol == CurrencySymbol.EUR)
                return GetEURExchangeRate(currencySymbol);
            if (currencySymbol == CurrencySymbol.GBP)
                return GetGBPExchangeRate(currencySymbol);
            else
                return GetUSDExchangeRate(currencySymbol);                
        }

        private IEnumerable<double> GetEURExchangeRate(CurrencySymbol currencySymbol){           
            var rates = currencyService.GetEURData();
            var value = rates.rates.Select(x => x.mid);
            
            return value;              
        }
        private IEnumerable<double> GetGBPExchangeRate(CurrencySymbol currencySymbol){           
            var rates = currencyService.GetGBPData();
            var value = rates.rates.Select(x => x.mid);
            
            return value;              
        }        
        private IEnumerable<double> GetUSDExchangeRate(CurrencySymbol currencySymbol){           
            var rates = currencyService.GetUSDData();
            var value = rates.rates.Select(x => x.mid);
            
            return value;              
        }    
        // private double GetEURExchangeRate(CurrencySymbol currencySymbol){           
        //     var rates = currencyService.GetEURData().Select(x => x.rates);
                
        //     foreach(var value in rates){
        //         value.Select(a => exchange = a.mid);                    
        //     }
        //     return exchange;              
        // }
        // private double GetGBPExchangeRate(CurrencySymbol currencySymbol){            
        //     var rates = currencyService.GetGBPData().Select(x => x.rates);
                
        //     foreach(var value in rates){
        //         value.Select(a => exchange = a.mid);                    
        //     }
        //     return exchange;           
        // }   
        // private double GetUSDExchangeRate(CurrencySymbol currencySymbol){
        //     var rates = currencyService.GetGBPData().Select(x => x.rates);
                
        //     foreach(var value in rates){
        //         value.Select(a => exchange = a.mid);                    
        //     }
        //     return exchange;
        // }     
        

    }
}
