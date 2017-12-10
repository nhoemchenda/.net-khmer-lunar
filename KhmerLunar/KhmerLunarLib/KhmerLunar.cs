using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KhmerLunarLib
{
    public class KhmerLunar
    {
        public static string getCalendarLeap(int BEYear)
        {
            string leap = getBoditheyLeap(BEYear);
            string leapP = getBoditheyLeap(BEYear - 1);
            if (leap.Equals("MD"))
            {
                return "M";
            }

            if (leapP.Equals("MD"))
            {
                return "D";
            }

            return leap;
        }
        public static string getBoditheyLeap(int BEYear)

        {
            string str = "";
            bool isLeapDayYear = false;
            /*Current Year*/
            int Aharkun_mod = (BEYear * 292207 + 499) % 800;
            int Kromthupul = 800 - Aharkun_mod;
            bool isKhmerSolarLeap = false;
            if (Kromthupul <= 207)
            {
                isKhmerSolarLeap = true;
            }
            /*End Current Year*/
            int aharkun = (int)(Math.Floor((double)(BEYear * 292207 + 499)) / 800) + 4;
            int avoman = (aharkun * 11 + 25) % 692;
            int aharkun_n = (int)(Math.Floor((double)((BEYear + 1) * 292207 + 499)) / 800) + 4;
            int avoman_n = (aharkun_n * 11 + 25) % 692;
            int aharkun_p = (int)(Math.Floor((double)((BEYear + 1) * 292207 + 499)) / 800) + 4;
            int avoman_p = (aharkun_n * 11 + 25) % 692;
            if (isKhmerSolarLeap && avoman < 127)
            {
                isLeapDayYear = true;
            }
            else
            {
                if (avoman < 138)
                {
                    isLeapDayYear = true;
                }
                if (avoman == 137 && avoman_n == 0)
                {
                    isLeapDayYear = false;
                }
                if (avoman_p == 138 && avoman == 0)
                {
                    isLeapDayYear = true;
                }
            }
            int temp = (int)Math.Floor((double)((aharkun * 11 + 25) / 692));
            int bodithey = (temp + aharkun + 29) % 30;
            int temp_n = (int)Math.Floor((double)((aharkun_n * 11 + 25) / 692));
            int bodithey_n = (temp_n + aharkun_n + 29) % 30;
            bool isLeapMonth = false;
            if (bodithey < 6 || bodithey > 24)
            {
                isLeapMonth = true;
            }
            if (bodithey == 24 && bodithey_n == 6)
            {
                isLeapMonth = true;
            }
            if (bodithey == 25 && bodithey_n == 5)
            {
                isLeapMonth = false;
            }
            if (isLeapMonth && isLeapDayYear)
            {
                str = "MD";
            }
            else if (isLeapMonth)
            {
                str = "M";
            }
            else if (isLeapDayYear)
            {
                str = "D";
            }
            //Console.WriteLine(BEYear.ToString() + "\t" + BEYear.ToString() + "\t" + aharkun.ToString() + "\t" + avoman.ToString() + "\t" + bodithey.ToString() + "\t" + str + "\t");
            return str;
        }

        public static Hashtable getHashMonth()
        {
            Hashtable hsMonth = new Hashtable();
            hsMonth.Add("01", "មិគសិរ");
            hsMonth.Add("02", "បុស្ស");
            hsMonth.Add("03", "មាឃ");
            hsMonth.Add("04", "ផល្គុន");
            hsMonth.Add("05", "ចេត្រ");
            hsMonth.Add("06", "ពិសាខ");
            hsMonth.Add("07", "ជេស្ឋ");
            hsMonth.Add("08", "អាសាធ");
            hsMonth.Add("09", "បឋមសាធ");
            hsMonth.Add("10", "ទុតិយសាធ");
            hsMonth.Add("11", "ស្រាពណ៌");
            hsMonth.Add("12", "ភទ្របទ");
            hsMonth.Add("13", "អស្សុជ");
            hsMonth.Add("14", "កក្ដិក");

            return hsMonth;
        }
        public static string getKhmerLunarString(DateTime srcDate)
        {
            Hashtable hsMonth = getHashMonth();
            string enText = getKhmerLunarCode(srcDate);            
            string khText = "";
            string month = enText.Substring(0, 2);
            string kr = enText.Substring(2, 1);
            string d = enText.Substring(3, 2);
            string s = "";
            if (enText.Length == 6)
            {
                s = enText.Substring(5, 1);
            }

            if (s == "S")
            {
                s = "សីល";
            }
            month = hsMonth[month].ToString();
            kr = kr.Replace("K", "កើត").Replace("R", "រោច");
            int dt = int.Parse(d);
            d = dt.ToString().Replace("0", "០").Replace("1", "១").Replace("2", "២").Replace("3", "៣").Replace("4", "៤").Replace("5", "៥").Replace("6", "៦").Replace("7", "៧").Replace("8", "៨").Replace("9", "៩");
            khText = d + kr + " " + month;
            return khText;
        }

        public static string getKhmerLunarCode(DateTime srcDate)
        {
            Hashtable hsDay = new Hashtable();
            hsDay.Add(1, "01K01");
            hsDay.Add(2, "01K02");
            hsDay.Add(3, "01K03");
            hsDay.Add(4, "01K04");
            hsDay.Add(5, "01K05");
            hsDay.Add(6, "01K06");
            hsDay.Add(7, "01K07");
            hsDay.Add(8, "01K08S");
            hsDay.Add(9, "01K09");
            hsDay.Add(10, "01K10");
            hsDay.Add(11, "01K11");
            hsDay.Add(12, "01K12");
            hsDay.Add(13, "01K13");
            hsDay.Add(14, "01K14");
            hsDay.Add(15, "01K15S");
            hsDay.Add(16, "01R01");
            hsDay.Add(17, "01R02");
            hsDay.Add(18, "01R03");
            hsDay.Add(19, "01R04");
            hsDay.Add(20, "01R05");
            hsDay.Add(21, "01R06");
            hsDay.Add(22, "01R07");
            hsDay.Add(23, "01R08S");
            hsDay.Add(24, "01R09");
            hsDay.Add(25, "01R10");
            hsDay.Add(26, "01R11");
            hsDay.Add(27, "01R12");
            hsDay.Add(28, "01R13");
            hsDay.Add(29, "01R14S");
            hsDay.Add(30, "02K01");
            hsDay.Add(31, "02K02");
            hsDay.Add(32, "02K03");
            hsDay.Add(33, "02K04");
            hsDay.Add(34, "02K05");
            hsDay.Add(35, "02K06");
            hsDay.Add(36, "02K07");
            hsDay.Add(37, "02K08S");
            hsDay.Add(38, "02K09");
            hsDay.Add(39, "02K10");
            hsDay.Add(40, "02K11");
            hsDay.Add(41, "02K12");
            hsDay.Add(42, "02K13");
            hsDay.Add(43, "02K14");
            hsDay.Add(44, "02K15S");
            hsDay.Add(45, "02R01");
            hsDay.Add(46, "02R02");
            hsDay.Add(47, "02R03");
            hsDay.Add(48, "02R04");
            hsDay.Add(49, "02R05");
            hsDay.Add(50, "02R06");
            hsDay.Add(51, "02R07");
            hsDay.Add(52, "02R08S");
            hsDay.Add(53, "02R09");
            hsDay.Add(54, "02R10");
            hsDay.Add(55, "02R11");
            hsDay.Add(56, "02R12");
            hsDay.Add(57, "02R13");
            hsDay.Add(58, "02R14");
            hsDay.Add(59, "02R15S");
            hsDay.Add(60, "03K01");
            hsDay.Add(61, "03K02");
            hsDay.Add(62, "03K03");
            hsDay.Add(63, "03K04");
            hsDay.Add(64, "03K05");
            hsDay.Add(65, "03K06");
            hsDay.Add(66, "03K07");
            hsDay.Add(67, "03K08S");
            hsDay.Add(68, "03K09");
            hsDay.Add(69, "03K10");
            hsDay.Add(70, "03K11");
            hsDay.Add(71, "03K12");
            hsDay.Add(72, "03K13");
            hsDay.Add(73, "03K14");
            hsDay.Add(74, "03K15S");
            hsDay.Add(75, "03R01");
            hsDay.Add(76, "03R02");
            hsDay.Add(77, "03R03");
            hsDay.Add(78, "03R04");
            hsDay.Add(79, "03R05");
            hsDay.Add(80, "03R06");
            hsDay.Add(81, "03R07");
            hsDay.Add(82, "03R08S");
            hsDay.Add(83, "03R09");
            hsDay.Add(84, "03R10");
            hsDay.Add(85, "03R11");
            hsDay.Add(86, "03R12");
            hsDay.Add(87, "03R13");
            hsDay.Add(88, "03R14S");
            hsDay.Add(89, "04K01");
            hsDay.Add(90, "04K02");
            hsDay.Add(91, "04K03");
            hsDay.Add(92, "04K04");
            hsDay.Add(93, "04K05");
            hsDay.Add(94, "04K06");
            hsDay.Add(95, "04K07");
            hsDay.Add(96, "04K08S");
            hsDay.Add(97, "04K09");
            hsDay.Add(98, "04K10");
            hsDay.Add(99, "04K11");
            hsDay.Add(100, "04K12");
            hsDay.Add(101, "04K13");
            hsDay.Add(102, "04K14");
            hsDay.Add(103, "04K15S");
            hsDay.Add(104, "04R01");
            hsDay.Add(105, "04R02");
            hsDay.Add(106, "04R03");
            hsDay.Add(107, "04R04");
            hsDay.Add(108, "04R05");
            hsDay.Add(109, "04R06");
            hsDay.Add(110, "04R07");
            hsDay.Add(111, "04R08S");
            hsDay.Add(112, "04R09");
            hsDay.Add(113, "04R10");
            hsDay.Add(114, "04R11");
            hsDay.Add(115, "04R12");
            hsDay.Add(116, "04R13");
            hsDay.Add(117, "04R14");
            hsDay.Add(118, "04R15S");
            hsDay.Add(119, "05K01");
            hsDay.Add(120, "05K02");
            hsDay.Add(121, "05K03");
            hsDay.Add(122, "05K04");
            hsDay.Add(123, "05K05");
            hsDay.Add(124, "05K06");
            hsDay.Add(125, "05K07");
            hsDay.Add(126, "05K08S");
            hsDay.Add(127, "05K09");
            hsDay.Add(128, "05K10");
            hsDay.Add(129, "05K11");
            hsDay.Add(130, "05K12");
            hsDay.Add(131, "05K13");
            hsDay.Add(132, "05K14");
            hsDay.Add(133, "05K15S");
            hsDay.Add(134, "05R01");
            hsDay.Add(135, "05R02");
            hsDay.Add(136, "05R03");
            hsDay.Add(137, "05R04");
            hsDay.Add(138, "05R05");
            hsDay.Add(139, "05R06");
            hsDay.Add(140, "05R07");
            hsDay.Add(141, "05R08S");
            hsDay.Add(142, "05R09");
            hsDay.Add(143, "05R10");
            hsDay.Add(144, "05R11");
            hsDay.Add(145, "05R12");
            hsDay.Add(146, "05R13");
            hsDay.Add(147, "05R14S");
            hsDay.Add(148, "06K01");
            hsDay.Add(149, "06K02");
            hsDay.Add(150, "06K03");
            hsDay.Add(151, "06K04");
            hsDay.Add(152, "06K05");
            hsDay.Add(153, "06K06");
            hsDay.Add(154, "06K07");
            hsDay.Add(155, "06K08S");
            hsDay.Add(156, "06K09");
            hsDay.Add(157, "06K10");
            hsDay.Add(158, "06K11");
            hsDay.Add(159, "06K12");
            hsDay.Add(160, "06K13");
            hsDay.Add(161, "06K14");
            hsDay.Add(162, "06K15S");
            hsDay.Add(163, "06R01");
            hsDay.Add(164, "06R02");
            hsDay.Add(165, "06R03");
            hsDay.Add(166, "06R04");
            hsDay.Add(167, "06R05");
            hsDay.Add(168, "06R06");
            hsDay.Add(169, "06R07");
            hsDay.Add(170, "06R08S");
            hsDay.Add(171, "06R09");
            hsDay.Add(172, "06R10");
            hsDay.Add(173, "06R11");
            hsDay.Add(174, "06R12");
            hsDay.Add(175, "06R13");
            hsDay.Add(176, "06R14");
            hsDay.Add(177, "06R15S");
            hsDay.Add(178, "07K01");
            hsDay.Add(179, "07K02");
            hsDay.Add(180, "07K03");
            hsDay.Add(181, "07K04");
            hsDay.Add(182, "07K05");
            hsDay.Add(183, "07K06");
            hsDay.Add(184, "07K07");
            hsDay.Add(185, "07K08S");
            hsDay.Add(186, "07K09");
            hsDay.Add(187, "07K10");
            hsDay.Add(188, "07K11");
            hsDay.Add(189, "07K12");
            hsDay.Add(190, "07K13");
            hsDay.Add(191, "07K14");
            hsDay.Add(192, "07K15S");
            hsDay.Add(193, "07R01");
            hsDay.Add(194, "07R02");
            hsDay.Add(195, "07R03");
            hsDay.Add(196, "07R04");
            hsDay.Add(197, "07R05");
            hsDay.Add(198, "07R06");
            hsDay.Add(199, "07R07");
            hsDay.Add(200, "07R08S");
            hsDay.Add(201, "07R09");
            hsDay.Add(202, "07R10");
            hsDay.Add(203, "07R11");
            hsDay.Add(204, "07R12");
            hsDay.Add(205, "07R13");
            hsDay.Add(206, "07R14");//206
            hsDay.Add(207, "07R15S");//207
            hsDay.Add(208, "08K01");//208
            hsDay.Add(209, "08K02");
            hsDay.Add(210, "08K03");
            hsDay.Add(211, "08K04");
            hsDay.Add(212, "08K05");
            hsDay.Add(213, "08K06");
            hsDay.Add(214, "08K07");
            hsDay.Add(215, "08K08S");
            hsDay.Add(216, "08K09");
            hsDay.Add(217, "08K10");
            hsDay.Add(218, "08K11");
            hsDay.Add(219, "08K12");
            hsDay.Add(220, "08K13");
            hsDay.Add(221, "08K14");
            hsDay.Add(222, "08K15S");
            hsDay.Add(223, "08R01");
            hsDay.Add(224, "08R02");
            hsDay.Add(225, "08R03");
            hsDay.Add(226, "08R04");
            hsDay.Add(227, "08R05");
            hsDay.Add(228, "08R06");
            hsDay.Add(229, "08R07");
            hsDay.Add(230, "08R08S");
            hsDay.Add(231, "08R09");
            hsDay.Add(232, "08R10");
            hsDay.Add(233, "08R11");
            hsDay.Add(234, "08R12");
            hsDay.Add(235, "08R13");
            hsDay.Add(236, "08R14");
            hsDay.Add(237, "08R15S");//237
            hsDay.Add(238, "09K01");
            hsDay.Add(239, "09K02");
            hsDay.Add(240, "09K03");
            hsDay.Add(241, "09K04");
            hsDay.Add(242, "09K05");
            hsDay.Add(243, "09K06");
            hsDay.Add(244, "09K07");
            hsDay.Add(245, "09K08S");
            hsDay.Add(246, "09K09");
            hsDay.Add(247, "09K10");
            hsDay.Add(248, "09K11");
            hsDay.Add(249, "09K12");
            hsDay.Add(250, "09K13");
            hsDay.Add(251, "09K14");
            hsDay.Add(252, "09K15S");
            hsDay.Add(253, "09R01");
            hsDay.Add(254, "09R02");
            hsDay.Add(255, "09R03");
            hsDay.Add(256, "09R04");
            hsDay.Add(257, "09R05");
            hsDay.Add(258, "09R06");
            hsDay.Add(259, "09R07");
            hsDay.Add(260, "09R08S");
            hsDay.Add(261, "09R09");
            hsDay.Add(262, "09R10");
            hsDay.Add(263, "09R11");
            hsDay.Add(264, "09R12");
            hsDay.Add(265, "09R13");
            hsDay.Add(266, "09R14");
            hsDay.Add(267, "09R15S");
            hsDay.Add(268, "10K01");
            hsDay.Add(269, "10K02");
            hsDay.Add(270, "10K03");
            hsDay.Add(271, "10K04");
            hsDay.Add(272, "10K05");
            hsDay.Add(273, "10K06");
            hsDay.Add(274, "10K07");
            hsDay.Add(275, "10K08S");
            hsDay.Add(276, "10K09");
            hsDay.Add(277, "10K10");
            hsDay.Add(278, "10K11");
            hsDay.Add(279, "10K12");
            hsDay.Add(280, "10K13");
            hsDay.Add(281, "10K14");
            hsDay.Add(282, "10K15S");
            hsDay.Add(283, "10R01");
            hsDay.Add(284, "10R02");
            hsDay.Add(285, "10R03");
            hsDay.Add(286, "10R04");
            hsDay.Add(287, "10R05");
            hsDay.Add(288, "10R06");
            hsDay.Add(289, "10R07");
            hsDay.Add(290, "10R08S");
            hsDay.Add(291, "10R09");
            hsDay.Add(292, "10R10");
            hsDay.Add(293, "10R11");
            hsDay.Add(294, "10R12");
            hsDay.Add(295, "10R13");
            hsDay.Add(296, "10R14");
            hsDay.Add(297, "10R15S");
            hsDay.Add(298, "11K01");//298
            hsDay.Add(299, "11K02");
            hsDay.Add(300, "11K03");
            hsDay.Add(301, "11K04");
            hsDay.Add(302, "11K05");
            hsDay.Add(303, "11K06");
            hsDay.Add(304, "11K07");
            hsDay.Add(305, "11K08S");
            hsDay.Add(306, "11K09");
            hsDay.Add(307, "11K10");
            hsDay.Add(308, "11K11");
            hsDay.Add(309, "11K12");
            hsDay.Add(310, "11K13");
            hsDay.Add(311, "11K14");
            hsDay.Add(312, "11K15S");
            hsDay.Add(313, "11R01");
            hsDay.Add(314, "11R02");
            hsDay.Add(315, "11R03");
            hsDay.Add(316, "11R04");
            hsDay.Add(317, "11R05");
            hsDay.Add(318, "11R06");
            hsDay.Add(319, "11R07");
            hsDay.Add(320, "11R08S");
            hsDay.Add(321, "11R09");
            hsDay.Add(322, "11R10");
            hsDay.Add(323, "11R11");
            hsDay.Add(324, "11R12");
            hsDay.Add(325, "11R13");
            hsDay.Add(326, "11R14S");
            hsDay.Add(327, "12K01");
            hsDay.Add(328, "12K02");
            hsDay.Add(329, "12K03");
            hsDay.Add(330, "12K04");
            hsDay.Add(331, "12K05");
            hsDay.Add(332, "12K06");
            hsDay.Add(333, "12K07");
            hsDay.Add(334, "12K08S");
            hsDay.Add(335, "12K09");
            hsDay.Add(336, "12K10");
            hsDay.Add(337, "12K11");
            hsDay.Add(338, "12K12");
            hsDay.Add(339, "12K13");
            hsDay.Add(340, "12K14");
            hsDay.Add(341, "12K15S");
            hsDay.Add(342, "12R01");
            hsDay.Add(343, "12R02");
            hsDay.Add(344, "12R03");
            hsDay.Add(345, "12R04");
            hsDay.Add(346, "12R05");
            hsDay.Add(347, "12R06");
            hsDay.Add(348, "12R07");
            hsDay.Add(349, "12R08S");
            hsDay.Add(350, "12R09");
            hsDay.Add(351, "12R10");
            hsDay.Add(352, "12R11");
            hsDay.Add(353, "12R12");
            hsDay.Add(354, "12R13");
            hsDay.Add(355, "12R14");
            hsDay.Add(356, "12R15S");
            hsDay.Add(357, "13K01");
            hsDay.Add(358, "13K02");
            hsDay.Add(359, "13K03");
            hsDay.Add(360, "13K04");
            hsDay.Add(361, "13K05");
            hsDay.Add(362, "13K06");
            hsDay.Add(363, "13K07");
            hsDay.Add(364, "13K08S");
            hsDay.Add(365, "13K09");
            hsDay.Add(366, "13K10");
            hsDay.Add(367, "13K11");
            hsDay.Add(368, "13K12");
            hsDay.Add(369, "13K13");
            hsDay.Add(370, "13K14");
            hsDay.Add(371, "13K15S");
            hsDay.Add(372, "13R01");
            hsDay.Add(373, "13R02");
            hsDay.Add(374, "13R03");
            hsDay.Add(375, "13R04");
            hsDay.Add(376, "13R05");
            hsDay.Add(377, "13R06");
            hsDay.Add(378, "13R07");
            hsDay.Add(379, "13R08S");
            hsDay.Add(380, "13R09");
            hsDay.Add(381, "13R10");
            hsDay.Add(382, "13R11");
            hsDay.Add(383, "13R12");
            hsDay.Add(384, "13R13");
            hsDay.Add(385, "13R14S");
            hsDay.Add(386, "14K01");
            hsDay.Add(387, "14K02");
            hsDay.Add(388, "14K03");
            hsDay.Add(389, "14K04");
            hsDay.Add(390, "14K05");
            hsDay.Add(391, "14K06");
            hsDay.Add(392, "14K07");
            hsDay.Add(393, "14K08S");
            hsDay.Add(394, "14K09");
            hsDay.Add(395, "14K10");
            hsDay.Add(396, "14K11");
            hsDay.Add(397, "14K12");
            hsDay.Add(398, "14K13");
            hsDay.Add(399, "14K14");
            hsDay.Add(400, "14K15S");
            hsDay.Add(401, "14R01");
            hsDay.Add(402, "14R02");
            hsDay.Add(403, "14R03");
            hsDay.Add(404, "14R04");
            hsDay.Add(405, "14R05");
            hsDay.Add(406, "14R06");
            hsDay.Add(407, "14R07");
            hsDay.Add(408, "14R08S");
            hsDay.Add(409, "14R09");
            hsDay.Add(410, "14R10");
            hsDay.Add(411, "14R11");
            hsDay.Add(412, "14R12");
            hsDay.Add(413, "14R13");
            hsDay.Add(414, "14R14");
            hsDay.Add(415, "14R15S");


            //predfine by year hash on date 01 Jan
            int minDefineYear = 1900;
            int maxDefineYear = 2100;

            Hashtable hsYear = new Hashtable();
            hsYear.Add(1900, 30);
            hsYear.Add(1901, 41);
            hsYear.Add(1902, 22);
            hsYear.Add(1903, 32);
            hsYear.Add(1904, 43);
            hsYear.Add(1905, 25);
            hsYear.Add(1906, 36);
            hsYear.Add(1907, 46);
            hsYear.Add(1908, 27);
            hsYear.Add(1909, 39);
            hsYear.Add(1910, 20);
            hsYear.Add(1911, 31);
            hsYear.Add(1912, 41);
            hsYear.Add(1913, 23);
            hsYear.Add(1914, 34);
            hsYear.Add(1915, 45);
            hsYear.Add(1916, 26);
            hsYear.Add(1917, 38);
            hsYear.Add(1918, 48);
            hsYear.Add(1919, 29);
            hsYear.Add(1920, 40);
            hsYear.Add(1921, 22);
            hsYear.Add(1922, 33);
            hsYear.Add(1923, 43);
            hsYear.Add(1924, 24);
            hsYear.Add(1925, 36);
            hsYear.Add(1926, 47);
            hsYear.Add(1927, 28);
            hsYear.Add(1928, 38);
            hsYear.Add(1929, 20);
            hsYear.Add(1930, 31);
            hsYear.Add(1931, 42);
            hsYear.Add(1932, 23);
            hsYear.Add(1933, 34);
            hsYear.Add(1934, 45);
            hsYear.Add(1935, 26);
            hsYear.Add(1936, 37);
            hsYear.Add(1937, 49);
            hsYear.Add(1938, 30);
            hsYear.Add(1939, 40);
            hsYear.Add(1940, 21);
            hsYear.Add(1941, 33);
            hsYear.Add(1942, 44);
            hsYear.Add(1943, 25);
            hsYear.Add(1944, 35);
            hsYear.Add(1945, 47);
            hsYear.Add(1946, 28);
            hsYear.Add(1947, 39);
            hsYear.Add(1948, 20);
            hsYear.Add(1949, 31);
            hsYear.Add(1950, 42);
            hsYear.Add(1951, 23);
            hsYear.Add(1952, 34);
            hsYear.Add(1953, 46);
            hsYear.Add(1954, 27);
            hsYear.Add(1955, 37);
            hsYear.Add(1956, 48);
            hsYear.Add(1957, 30);
            hsYear.Add(1958, 41);
            hsYear.Add(1959, 22);
            hsYear.Add(1960, 32);
            hsYear.Add(1961, 44);
            hsYear.Add(1962, 25);
            hsYear.Add(1963, 36);
            hsYear.Add(1964, 46);
            hsYear.Add(1965, 28);
            hsYear.Add(1966, 39);
            hsYear.Add(1967, 20);
            hsYear.Add(1968, 31);
            hsYear.Add(1969, 42);
            hsYear.Add(1970, 23);
            hsYear.Add(1971, 34);
            hsYear.Add(1972, 45);
            hsYear.Add(1973, 27);
            hsYear.Add(1974, 37);
            hsYear.Add(1975, 48);
            hsYear.Add(1976, 29);
            hsYear.Add(1977, 41);
            hsYear.Add(1978, 22);
            hsYear.Add(1979, 32);
            hsYear.Add(1980, 43);
            hsYear.Add(1981, 25);
            hsYear.Add(1982, 36);
            hsYear.Add(1983, 47);
            hsYear.Add(1984, 28);
            hsYear.Add(1985, 39);
            hsYear.Add(1986, 20);
            hsYear.Add(1987, 31);
            hsYear.Add(1988, 42);
            hsYear.Add(1989, 24);
            hsYear.Add(1990, 34);
            hsYear.Add(1991, 45);
            hsYear.Add(1992, 26);
            hsYear.Add(1993, 38);
            hsYear.Add(1994, 19);
            hsYear.Add(1995, 29);
            hsYear.Add(1996, 40);
            hsYear.Add(1997, 22);
            hsYear.Add(1998, 33);
            hsYear.Add(1999, 44);
            hsYear.Add(2000, 25);
            hsYear.Add(2001, 36);
            hsYear.Add(2002, 47);
            hsYear.Add(2003, 28);
            hsYear.Add(2004, 39);
            hsYear.Add(2005, 21);
            hsYear.Add(2006, 31);
            hsYear.Add(2007, 42);
            hsYear.Add(2008, 23);
            hsYear.Add(2009, 35);
            hsYear.Add(2010, 45);
            hsYear.Add(2011, 26);
            hsYear.Add(2012, 37);
            hsYear.Add(2013, 19);
            hsYear.Add(2014, 30);
            hsYear.Add(2015, 41);
            hsYear.Add(2016, 22);
            hsYear.Add(2017, 33);
            hsYear.Add(2018, 44);
            hsYear.Add(2019, 25);
            hsYear.Add(2020, 36);
            hsYear.Add(2021, 47);
            hsYear.Add(2022, 28);
            hsYear.Add(2023, 39);
            hsYear.Add(2024, 20);
            hsYear.Add(2025, 32);
            hsYear.Add(2026, 42);
            hsYear.Add(2027, 23);
            hsYear.Add(2028, 34);
            hsYear.Add(2029, 46);
            hsYear.Add(2030, 27);
            hsYear.Add(2031, 37);
            hsYear.Add(2032, 18);
            hsYear.Add(2033, 30);
            hsYear.Add(2034, 41);
            hsYear.Add(2035, 22);
            hsYear.Add(2036, 32);
            hsYear.Add(2037, 44);
            hsYear.Add(2038, 25);
            hsYear.Add(2039, 36);
            hsYear.Add(2040, 47);
            hsYear.Add(2041, 29);
            hsYear.Add(2042, 39);
            hsYear.Add(2043, 20);
            hsYear.Add(2044, 31);
            hsYear.Add(2045, 43);
            hsYear.Add(2046, 24);
            hsYear.Add(2047, 34);
            hsYear.Add(2048, 45);
            hsYear.Add(2049, 27);
            hsYear.Add(2050, 38);
            hsYear.Add(2051, 19);
            hsYear.Add(2052, 29);
            hsYear.Add(2053, 41);
            hsYear.Add(2054, 22);
            hsYear.Add(2055, 33);
            hsYear.Add(2056, 44);
            hsYear.Add(2057, 26);
            hsYear.Add(2058, 36);
            hsYear.Add(2059, 47);
            hsYear.Add(2060, 28);
            hsYear.Add(2061, 40);
            hsYear.Add(2062, 21);
            hsYear.Add(2063, 31);
            hsYear.Add(2064, 42);
            hsYear.Add(2065, 24);
            hsYear.Add(2066, 35);
            hsYear.Add(2067, 45);
            hsYear.Add(2068, 26);
            hsYear.Add(2069, 38);
            hsYear.Add(2070, 19);
            hsYear.Add(2071, 30);
            hsYear.Add(2072, 40);
            hsYear.Add(2073, 22);
            hsYear.Add(2074, 33);
            hsYear.Add(2075, 44);
            hsYear.Add(2076, 25);
            hsYear.Add(2077, 36);
            hsYear.Add(2078, 47);
            hsYear.Add(2079, 28);
            hsYear.Add(2080, 39);
            hsYear.Add(2081, 21);
            hsYear.Add(2082, 32);
            hsYear.Add(2083, 42);
            hsYear.Add(2084, 23);
            hsYear.Add(2085, 35);
            hsYear.Add(2086, 46);
            hsYear.Add(2087, 27);
            hsYear.Add(2088, 37);
            hsYear.Add(2089, 19);
            hsYear.Add(2090, 30);
            hsYear.Add(2091, 41);
            hsYear.Add(2092, 22);
            hsYear.Add(2093, 33);
            hsYear.Add(2094, 44);
            hsYear.Add(2095, 25);
            hsYear.Add(2096, 36);
            hsYear.Add(2097, 48);
            hsYear.Add(2098, 29);
            hsYear.Add(2099, 39);
            hsYear.Add(2100, 20);

            DateTime beginDate = DateTime.Parse("1900-01-01");
            
            int correspondNum = 30;

            if (srcDate.Year > maxDefineYear)
            {
                beginDate = DateTime.Parse(maxDefineYear.ToString() + "-01-01");
                correspondNum = (int)hsYear[maxDefineYear];
            }
            else if (srcDate.Year < minDefineYear)
            {
                throw new Exception("Uncalculatable");
            }
            else
            {
                beginDate = DateTime.Parse(srcDate.Year.ToString() + "-01-01");
                correspondNum = (int)hsYear[srcDate.Year];
            }

            DateTime tmpDate = beginDate;
            int diffDate = srcDate.Subtract(beginDate).Days;
            int cNum = correspondNum;


            for (int i = 0; i < diffDate; i++)
            {
                string leap = getCalendarLeap(tmpDate.AddDays(i).Year + 544);
                cNum = cNum + 1;
                if (cNum == 207)
                {
                    if (!(leap == "D"))
                    {
                        cNum = 208;
                    }
                }

                if (cNum == 208)
                {
                    if (leap == "M")
                    {
                        cNum = 238;
                    }
                }

                if (cNum == 238)
                {
                    if (leap != "M")
                    {
                        cNum = 298;
                    }
                }

                if (cNum == 416)
                {
                    cNum = 1;
                }
            }

            //return cNum.ToString();

            string result = hsDay[cNum].ToString();
            if(result == "07R14" && getCalendarLeap(srcDate.Year + 544) != "D")
            {
                result = result + "S";
            }
            return result;

        }
    }
}
