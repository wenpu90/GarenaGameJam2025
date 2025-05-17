using UnityEngine;

using System.Collections.Generic;

public class MarqueeText : MonoBehaviour
{
    [System.Serializable]
    public class NewsLine
    {
        public string zh;
        public string en;

        public NewsLine(string zh, string en)
        {
            this.zh = zh;
            this.en = en;
        }
    }

    private List<NewsLine> villainNewsLines = new List<NewsLine>
    {
        new NewsLine("Mr. Bonk 再次出擊！歹徒被擊飛三棟樓遠，目擊者表示像是沙發飛過去。", "Mr. Bonk strikes again! Villain launched over three buildings — eyewitness says it looked like a flying sofa."),
        new NewsLine("英雄還是怪手？Mr. Bonk 一拳把歹徒打進麵店，老闆怒求賠水餃。", "Hero or bulldozer? Mr. Bonk punches thug into a noodle shop — shop owner demands compensation for dumplings."),
        new NewsLine("城市又一次被拯救了，但街道又壞了。Mr. Bonk 到此一遊。", "City saved, again. Street destroyed, again. Mr. Bonk was here."),
        new NewsLine("獨家：Mr. Bonk 第八度拯救城市！房價持續創新低。", "Exclusive: Mr. Bonk saves the day for the 8th time — local housing prices hit a new low."),
        new NewsLine("歹徒被 Mr. Bonk 打飛，目擊者說：「悲壯又好看。」", "Villain goes airborne thanks to Mr. Bonk — bystanders describe it as 'tragic, yet oddly majestic.'"),
        new NewsLine("一拳一坑洞！Mr. Bonk 最新行動讓整條馬路重鋪。", "One punch, one pothole: Mr. Bonk’s latest rescue mission triggers full road reconstruction."),
        new NewsLine("Mr. Bonk 英勇打擊犯罪，但順便拆了市長的競選看板。", "Mr. Bonk praised for stopping crime — also accidentally destroyed mayor’s campaign billboard."),
        new NewsLine("銀行搶匪剛想逃跑，就被 Mr. Bonk 的穿牆拳抓包！", "Bank robbers caught mid-getaway — thanks to Mr. Bonk, and the new hole in the wall."),
        new NewsLine("市民感謝 Mr. Bonk 打飛歹徒，但也希望他不要順便撞飛他們的車。", "Citizens grateful Mr. Bonk stopped the criminal, but wish he hadn’t bonked their cars too."),
        new NewsLine("Mr. Bonk 一拳把歹徒送進噴水池，免費泡湯一次，無附毛巾。", "Thug flies into fountain after Mr. Bonk’s heroic slam — gets free public bath, no towel included.")
    };

    private List<NewsLine> citizenNewsLines = new List<NewsLine>
    {
        new NewsLine("Mr. Bonk 英勇衝刺，意外撞飛遛狗阿姨，狗狗目前情緒穩定。", "Mr. Bonk charged heroically, accidentally sending a dog-walking aunt flying. The dog is reportedly calm."),
        new NewsLine("超人撞飛歹徒也撞飛路人！Mr. Bonk 送市民免費搭雲霄飛車。", "Thug down, pedestrian airborne! Mr. Bonk offers free rollercoaster rides — unintentionally."),
        new NewsLine("市民投訴：我不是壞人，為何要被 Bonk 一拳送進噴泉？", "Citizen complains: ‘I’m not a villain — why did Bonk punch me into the fountain?’"),
        new NewsLine("Mr. Bonk 撞飛外送員，餐點灑落民眾頭上，意外變街頭 buffet。", "Mr. Bonk crashes into a food courier — meals now served rooftop-style."),
        new NewsLine("英雄衝太快！Mr. Bonk 送一對新人從紅毯上起飛進婚禮蛋糕。", "Mr. Bonk charges through wedding — newlyweds launched directly into cake."),
        new NewsLine("Mr. Bonk 英勇出擊！市民與歹徒同時飛出畫面，分不清誰是誰。", "Mr. Bonk's bold strike sends both thug and bystander flying — no one knows who’s who anymore."),
        new NewsLine("路人經歷 Bonk 衝撞後受訪：『感覺像坐飛機沒繫安全帶。』", "Bystander after Bonk collision: ‘Like flying economy without a seatbelt.’"),
        new NewsLine("市長呼籲 Mr. Bonk 練好轉彎技巧，再愛市民一次！", "Mayor urges Mr. Bonk to practice turning — ‘Love your citizens, don’t launch them.’"),
        new NewsLine("Mr. Bonk 誤撞市民後公開道歉，送出擁抱券一張。", "Mr. Bonk apologizes after citizen impact — offers a free hug voucher."),
        new NewsLine("民眾抗議：今天不是壞人，卻被 Mr. Bonk bonk 到脫鞋。", "Citizen protests: ‘I wasn’t a villain today — but Mr. Bonk knocked off my shoes!’")
    };

    private List<NewsLine> buildingNewsLines = new List<NewsLine>
    {
        new NewsLine("Mr. Bonk 英勇過頭！撞進百貨公司造成八層樓瘫痪。", "Mr. Bonk goes too hard — crashes through mall, disables eight floors."),
        new NewsLine("市圖書館被 Mr. Bonk 拆掉半邊，書籍飛成知識龍捲風。", "Library loses a wing to Mr. Bonk — books now form a knowledge tornado."),
        new NewsLine("Bonk 英雄一拳擊破水塔，全城免費洗冷水澡。", "Mr. Bonk punches water tower — entire city gets a surprise cold shower."),
        new NewsLine("天橋不是壞人！Mr. Bonk 誤判擊倒整條天橋。", "Overpass not evil — Mr. Bonk knocks it out anyway."),
        new NewsLine("Bonk 力過猛，撞破學校大門，學生提早放寒假。", "Mr. Bonk smashes school gates — students celebrate early winter break."),
        new NewsLine("Mr. Bonk 拯救城市順手拆了市政廳，市長辦公桌仍在尋找中。", "Mr. Bonk saves the day — and dismantles city hall. Mayor’s desk missing."),
        new NewsLine("一撞雙得：歹徒與郵筒同時被 Bonk 撞碎。", "Double knock-out: thug and mailbox both obliterated by Mr. Bonk."),
        new NewsLine("警告：請遠離玻璃建築，Bonk 可能會來一記迎面撞擊。", "Alert: Stay clear of glass buildings — Bonk inbound!"),
        new NewsLine("超市玻璃門被 Mr. Bonk 撞出人型破洞，現場民眾表示太寫實。", "Supermarket entrance now features a Bonk-shaped hole — shoppers impressed."),
        new NewsLine("市政工程宣布新項目：『Bonk保險防撞牆』正式啟動。", "City unveils new infrastructure: ‘Bonk-proof barriers’ under construction.")
    };

    public string GetRandomVillainNews()
    {
        int index = Random.Range(0, villainNewsLines.Count);
        return villainNewsLines[index].zh;
    }

    public string GetRandomCitizenNews()
    {
        int index = Random.Range(0, citizenNewsLines.Count);
        return citizenNewsLines[index].zh;
    }

    public string GetRandomBuildingNews()
    {
        int index = Random.Range(0, buildingNewsLines.Count);
        return buildingNewsLines[index].zh;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
