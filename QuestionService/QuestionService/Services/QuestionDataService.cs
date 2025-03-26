using System.Collections.Generic;
using System.Linq;
using QuestionService.Models;

namespace QuestionService.Services
{
    public class QuestionDataService
    {
        private static readonly List<Question> _questions = new List<Question>
        {
            new Question { Id = 1, Text = "คุณอยากสัมผัสบรรยากาศสงกรานต์แบบไหน?", Options = new List<string> { "คึกคัก สนุกสนาน เน้นการสาดน้ำและปาร์ตี้", "เงียบสงบ ผ่อนคลาย เน้นวัฒนธรรมและประเพณี", "ผสมผสานความสนุกสนานและการพักผ่อน", "ยังไม่แน่ใจ / แล้วแต่สถานที่แนะนำ" } },
            new Question { Id = 2, Text = "คุณวางแผนจะเดินทางไปเที่ยวสงกรานต์กับใคร?", Options = new List<string> { "ครอบครัว (มีเด็กเล็ก/ผู้สูงอายุ)", "กลุ่มเพื่อน", "คนรัก", "เดินทางคนเดียว" } },
            new Question { Id = 3, Text = "งบประมาณที่คุณตั้งไว้สำหรับทริปสงกรานต์นี้ประมาณเท่าไหร่?", Options = new List<string> { "ไม่เกิน 5,000 บาท", "5,000 - 15,000 บาท", "15,000 - 30,000 บาท", "มากกว่า 30,000 บาท", "ยังไม่กำหนดงบประมาณ" } },
            new Question { Id = 4, Text = "คุณสนใจกิจกรรมใดเป็นพิเศษในช่วงสงกรานต์?", Options = new List<string> { "การสาดน้ำและกิจกรรมกลางแจ้งสนุกๆ", "การทำบุญ ตักบาตร เข้าวัด", "การชมการแสดงทางวัฒนธรรมและประเพณี", "การพักผ่อนตามธรรมชาติ (ทะเล, ภูเขา)", "การเดินชมเมืองเก่า/สถานที่ทางประวัติศาสตร์" } },
            new Question { Id = 5, Text = "คุณสะดวกเดินทางไปเที่ยวสงกรานต์ในภูมิภาคใดของประเทศไทย?", Options = new List<string> { "ภาคเหนือ", "ภาคกลาง", "ภาคตะวันออกเฉียงเหนือ (อีสาน)", "ภาคตะวันออก", "ภาคใต้", "ไม่ได้จำกัดภูมิภาค" } },
            new Question { Id = 6, Text = "ในการท่องเที่ยว คุณให้ความสำคัญกับสิ่งใดมากที่สุด?", Options = new List<string> { "ความสนุกสนานและกิจกรรมหลากหลาย", "ความสะดวกสบายในการเดินทางและที่พัก", "โอกาสในการสัมผัสวัฒนธรรมและประเพณี", "บรรยากาศที่ผ่อนคลายและเงียบสงบ", "ความคุ้มค่าด้านราคา" } },
            new Question { Id = 7, Text = "คุณชอบเดินทางด้วยวิธีใดเป็นหลัก?", Options = new List<string> { "รถยนต์ส่วนตัว", "เครื่องบิน", "รถไฟ", "รถโดยสารประจำทาง", "แล้วแต่ความสะดวกของแต่ละทริป" } },
            new Question { Id = 8, Text = "คุณมีสถานที่ท่องเที่ยวในใจสำหรับสงกรานต์ปีหน้าแล้วหรือไม่?", Options = new List<string> { "มี", "ยังไม่มี" } },
            new Question { Id = 9, Text = "คุณอยากได้คำแนะนำสถานที่ท่องเที่ยวสงกรานต์ที่เน้นไปที่อะไรเป็นพิเศษ?", Options = new List<string> { "สถานทียอดนิยมที่มีคนไปเยอะ", "สถานที่ที่มีเอกลักษณ์ทางวัฒนธรรม", "สถานที่ที่เหมาะกับการพักผ่อนกับครอบครัว", "สถานที่ที่เดินทางสะดวกจาก [ระบุจังหวัดของคุณ]", "ไม่มีข้อจำกัดพิเศษ" } }
        };

        public IEnumerable<Question> GetQuestions()
        {
            return _questions;
        }

        public Question GetQuestionById(int id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            if (question == null)
            {
                throw new KeyNotFoundException($"ไม่พบคำถามที่มี ID {id}");
            }
            return question;
        }
    }
}