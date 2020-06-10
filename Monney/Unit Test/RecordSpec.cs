using System;
using Monney.Models;
using Xunit;

namespace Unit_Test
{
    public class RecordSpec
    {
        Monney.Models.Record record = new Monney.Models.Record();

        [Fact]
        public void Amount_is_settable()
        {
            record.Amount = 100;
            Assert.Equal(100, record.Amount);
        }

        [Fact]
        public void Category_is_settable()
        {
            record.Category = Category.Entertainment;
            Assert.Equal("Entertainment", record.Category.ToString());
        }

        [Fact]
        public void Date_is_selectable()
        {
            record.Date = DateTime.Today.Date;
            Assert.Equal(DateTime.Today.Date, record.Date);
        }
    }
}
