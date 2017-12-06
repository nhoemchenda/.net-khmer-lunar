# .net-khmer-lunar
.NET Project convert date to string of khmer lunar date

This repository consists of two project:
 + KhmerLunar: the testing application.
 + KhmerLunarLib: the core library for converting from date to string of khmer lunar
 
The points to be noted
 + Method: getKhmerLunarCode() will produce result like 02K15S or 01R07
      - 02 (First) , 01 (Second) stand for month where the list of khmer month string is produced by getHashMonth
      - K (First) , R (Second) stand for កើត (Kert) and រោច (Rouch)
      - 15 (First), 07 (Second) stand for the day in month
      - The last S character is to state that it is the holy-day (Sila)
Example: 02K15S: ខែបុស្ស ថ្ធៃសីល១៥កើត 01R07: ខែមិគសិរ ថ្ងៃ៧រោច
