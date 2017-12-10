# .net-khmer-lunar (In Development)
**.NET Project convert date to string of khmer lunar date**

This repository consists of two project:
 + KhmerLunar: the testing application.
 + KhmerLunarLib: the core library for converting from date to string of khmer lunar
 
**The points to be noted:**
 + Method **getKhmerLunarCode()** will produce result like **[2Digit of SAK][2Digit of Animal Year][4Digit of Year][2Digit of Month][1Character for Kert/Rouch][2Digit of Day][Option Character S]**:
	- Sak Description can be extracted from method **getHashMonth()**
	- Animal Year Description can be extracted from method **getHashAnimalYear()**
	- Year is the budha year (ព.ស)
	- Month Description can be extracted from method **getHashMonth()**
	- Kert/Rouch: **K** mean Kert(កើត) , **R** mean Rouch(រោច)
	- Optional S: mean holy-day (ថ្ងៃសីល)
 + Method **getKhmerLunarString** will produce full description in khmer.
 
 **Example1:** 
 Date: 2017-12-10 
 Code: 0910256101R07 (09 10 2561 01 R 07)
 Full Description: ថ្ងៃ ៧រោច ខែមិគសិរ ព.ស ២៥៦១ ឆ្នាំ រកា នព្វ​ស័ក
 
 **Example2:** 
 Date: 2018-01-01 
 Code: 0910256102K15S (09 10 2561 02 K 15 S)
 Full Description: ថ្ងៃ ១៥កើត ខែបុស្ស ព.ស ២៥៦១ ឆ្នាំ រកា នព្វ​ស័ក
**Note:**
**It is privately for this project to increase Budha era on first month of Chet month (១កើត ខែចេត្រ) .**
**So from that day the library will mark as new era.**
**Please be noted that it is really unofficial.**
