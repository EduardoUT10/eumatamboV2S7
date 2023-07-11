using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace eumatamboV2
{
    public interface Database
    {
      SQLiteAsyncConnection GetConnection();    
    }
}
