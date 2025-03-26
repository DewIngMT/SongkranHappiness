using System;
using System.Collections.Generic;
using System.Linq;
using RecommendationService.Models;

namespace RecommendationService.Services
{
    public class RecommendationLogicService
    {
        public RecommendationResult GetRecommendations(List<Answer> answers)
        {
            List<Recommendation> placeRecommendations = AnalyzeAnswersForPlaceRecommendations(answers);

            return new RecommendationResult
            {
                OriginalScore = 0,
                Recommendations = new List<string>(),
                PlaceRecommendations = placeRecommendations
            };
        }

        private List<Recommendation> AnalyzeAnswersForPlaceRecommendations(List<Answer> answers)
        {
            var placeRecommendations = new List<Recommendation>();
            var answerDictionary = answers.ToDictionary(a => a.QuestionId, a => a.SelectedOption?.ToLower());

            if (answerDictionary.ContainsKey(1))
            {
                if (answerDictionary[1].Contains("คึกคัก"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "เชียงใหม่", Description = "สัมผัสสงกรานต์สุดมันส์ มีการสาดน้ำและกิจกรรมหลากหลาย" });
                    placeRecommendations.Add(new Recommendation { Place = "ขอนแก่น", Description = "สนุกกับถนนข้าวเหนียวและเทศกาลสงกรานต์ที่คึกคัก" });
                }
                if (answerDictionary[1].Contains("เงียบสงบ"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "อยุธยา", Description = "สัมผัสสงกรานต์แบบดั้งเดิมและชมโบราณสถาน" });
                    placeRecommendations.Add(new Recommendation { Place = "สุโขทัย", Description = "ร่วมงานสงกรานต์ท่ามกลางบรรยากาศเมืองเก่า" });
                }
                if (answerDictionary[1].Contains("ผสมผสาน"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "หัวหิน", Description = "เมืองชายทะเลที่มีทั้งความสนุกและผ่อนคลายในช่วงสงกรานต์" });
                    placeRecommendations.Add(new Recommendation { Place = "พัทยา", Description = "มีกิจกรรมสงกรานต์หลากหลาย พร้อมแหล่งท่องเที่ยวอื่นๆ" });
                }
            }

            if (answerDictionary.ContainsKey(2))
            {
                if (answerDictionary[2].Contains("ครอบครัว"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "สวนน้ำ/สวนสนุก", Description = "สถานที่ที่เหมาะสำหรับกิจกรรมทั้งครอบครัว" });
                    placeRecommendations.Add(new Recommendation { Place = "รีสอร์ทริมทะเล/ภูเขา", Description = "พักผ่อนสบายๆ พร้อมกิจกรรมสำหรับทุกคน" });
                }
                if (answerDictionary[2].Contains("กลุ่มเพื่อน"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "เกาะต่างๆ (เช่น ภูเก็ต, สมุย)", Description = "สนุกกับกิจกรรมทางน้ำและปาร์ตี้ริมหาด" });
                    placeRecommendations.Add(new Recommendation { Place = "แหล่งท่องเที่ยวที่มีกิจกรรม Adventure", Description = "ผจญภัยและสร้างความทรงจำกับเพื่อน" });
                }
                if (answerDictionary[2].Contains("คนรัก"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "สถานที่โรแมนติก (เช่น ปาย, เชียงคาน)", Description = "พักผ่อนในบรรยากาศเงียบสงบและสวยงาม" });
                    placeRecommendations.Add(new Recommendation { Place = "รีสอร์ทหรู บรรยากาศดี", Description = "เติมความหวานให้ทริปสงกรานต์" });
                }
                if (answerDictionary[2].Contains("คนเดียว"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "โฮสเทล/เกสต์เฮาส์ในเมืองที่มีชีวิตชีวา", Description = "พบปะผู้คนใหม่ๆ และสำรวจเมือง" });
                    placeRecommendations.Add(new Recommendation { Place = "สถานที่ทางประวัติศาสตร์/ธรรมชาติ", Description = "ใช้เวลาสำรวจและเรียนรู้ด้วยตัวเอง" });
                }
            }

            if (answerDictionary.ContainsKey(3))
            {
                if (answerDictionary[3].Contains("ไม่เกิน 5,000"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.EstimatedCost <= 7000).ToList();
                    placeRecommendations.Add(new Recommendation { Place = "จังหวัดใกล้เคียง", Description = "สำรวจสถานที่ท่องเที่ยวใกล้บ้านเพื่อประหยัดงบ" });
                }
                else if (answerDictionary[3].Contains("5,000 - 15,000"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.EstimatedCost >= 5000 && r.EstimatedCost <= 15000).ToList();
                }
                else if (answerDictionary[3].Contains("15,000 - 30,000"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.EstimatedCost >= 15000 && r.EstimatedCost <= 30000).ToList();
                }
                else if (answerDictionary[3].Contains("มากกว่า 30,000"))
                {
                    
                }
            }

            if (answerDictionary.ContainsKey(4))
            {
                if (answerDictionary[4].Contains("สาดน้ำ"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Activities.Contains("สาดน้ำ") || r.Description.Contains("สาดน้ำ")).ToList();
                    placeRecommendations.Add(new Recommendation { Place = "ถนนคนเดินสงกรานต์", Description = "เข้าร่วมงานสงกรานต์ที่มีการสาดน้ำสนุกสนาน" });
                }
                if (answerDictionary[4].Contains("ทำบุญ"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "วัดสำคัญในจังหวัดต่างๆ", Description = "ร่วมพิธีทำบุญ ตักบาตร และสรงน้ำพระ" });
                }
                if (answerDictionary[4].Contains("วัฒนธรรม"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "อุทยานประวัติศาสตร์", Description = "ชมการแสดงทางวัฒนธรรมและประเพณีสงกรานต์" });
                    placeRecommendations.Add(new Recommendation { Place = "ชุมชนเก่าแก่", Description = "สัมผัสวิถีชีวิตและประเพณีสงกรานต์ดั้งเดิม" });
                }
                if (answerDictionary[4].Contains("พักผ่อน"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Activities.Contains("พักผ่อนริมทะเล") || r.Activities.Contains("เดินป่า") || r.Description.Contains("พักผ่อน")).ToList();
                    placeRecommendations.Add(new Recommendation { Place = "รีสอร์ทเงียบสงบ", Description = "หลีกหนีความวุ่นวายและพักผ่อนอย่างเต็มที่" });
                }
                if (answerDictionary[4].Contains("ชมเมืองเก่า"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "เมืองเก่า (เช่น เชียงใหม่, ภูเก็ต)", Description = "เดินชมสถาปัตยกรรมและสัมผัสบรรยากาศเมืองเก่าในช่วงสงกรานต์" });
                }
            }

            if (answerDictionary.ContainsKey(5))
            {
                if (answerDictionary[5].Contains("ภาคเหนือ"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Region == "ภาคเหนือ" || r.Region == "ภาคเหนือตอนล่าง").ToList();
                }
                if (answerDictionary[5].Contains("ภาคกลาง"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Region == "ภาคกลาง").ToList();
                }
                if (answerDictionary[5].Contains("ภาคตะวันออกเฉียงเหนือ"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Region == "ภาคตะวันออกเฉียงเหนือ").ToList();
                }
                if (answerDictionary[5].Contains("ภาคตะวันออก"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Region == "ภาคตะวันออก").ToList();
                }
                if (answerDictionary[5].Contains("ภาคใต้"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Region == "ภาคใต้" || r.Region == "ภาคใต้ตอนบน").ToList();
                }
            }

            if (answerDictionary.ContainsKey(6))
            {
                if (answerDictionary[6].Contains("ความสนุกสนาน"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Activities.Contains("สาดน้ำ") || r.Description.Contains("คึกคัก")).ToList();
                }
                if (answerDictionary[6].Contains("ความสะดวกสบาย"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "เมืองหลักที่มีสิ่งอำนวยความสะดวกครบครัน", Description = "เลือกพักในเมืองที่มีการคมนาคมสะดวกและที่พักหลากหลาย" });
                }
                if (answerDictionary[6].Contains("วัฒนธรรม"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Activities.Contains("ทำบุญ") || r.Activities.Contains("ชมการแสดงทางวัฒนธรรม") || r.Description.Contains("วัฒนธรรม")).ToList();
                }
                if (answerDictionary[6].Contains("ผ่อนคลาย"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Activities.Contains("พักผ่อน") || r.Description.Contains("เงียบสงบ")).ToList();
                }
                if (answerDictionary[6].Contains("คุ้มค่า"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "จังหวัดรอง/เมืองเล็ก", Description = "อาจมีค่าใช้จ่ายที่พักและอาหารที่คุ้มค่ากว่า" });
                }
            }

            if (answerDictionary.ContainsKey(8) && answerDictionary[8].Contains("มี"))
            {
                placeRecommendations.Add(new Recommendation { Place = "สถานที่ที่คุณสนใจ", Description = "ลองพิจารณาสถานที่ที่คุณมีอยู่ในใจสำหรับสงกรานต์นี้" });
            }

            if (answerDictionary.ContainsKey(9))
            {
                if (answerDictionary[9].Contains("ยอดนิยม"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "สถานที่จัดงานสงกรานต์ใหญ่ๆ", Description = "เลือกไปในสถานที่ที่มีผู้คนนิยมไปร่วมงานกันมาก" });
                }
                if (answerDictionary[9].Contains("เอกลักษณ์ทางวัฒนธรรม"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Description.Contains("วัฒนธรรม") || r.Description.Contains("ดั้งเดิม")).ToList();
                }
                if (answerDictionary[9].Contains("พักผ่อนกับครอบครัว"))
                {
                    placeRecommendations = placeRecommendations.Where(r => r.Description.Contains("ครอบครัว") || r.Activities.Contains("สำหรับเด็ก")).ToList();
                }
                if (answerDictionary[9].Contains("เดินทางสะดวก"))
                {
                    placeRecommendations.Add(new Recommendation { Place = "สถานที่เดินทางสะดวก", Description = "พิจารณาสถานที่ที่เดินทางไปได้ง่ายตามวิธีการเดินทางที่คุณชอบ" });
                }
            }

            return placeRecommendations.DistinctBy(r => r.Place).ToList();
        }
    }
}