{%hackmd theme-dark %}

# LeetCode 

###### tags: `LeetCode`

[![hackmd-github-sync-badge](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ/badge)](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ)

## #1_Two Sum 
###### Related Topics: `Hash Table`
### 目標
給一個int陣列nums跟一個int target，nums當中會有兩個值合為target，且是唯一解
求那兩個值在nums中的index n, m，然後回傳int[] {n, m}
### 求解
- 查表法:
    nums[i] + nums[j] == taget → nums[j] == target - nums[i]
    尋找合為target的兩數這件是其實相當於尋找target減去nums某值得到的數X存不存在nums中，所以可以思考把nums的數存成一個Dictionary，key是數值value是對應的index，這樣可以在一層迴圈中一邊建表一邊搜尋X來把問題解決

## #2_Add Two Numbers
###### Related Topics: `Linked List`
### 目標
給兩個LinkedList，將兩邊的Node各別相加串成新的LinkedList回傳，如果相加超過10則要進位給下個Node，可能會有兩個LinkedList長度不一樣的情況
### 求解
- 直觀流程
    1. 建立一個回傳用的LinkedList，三個遍訪用的Node nodeCurrent, nodeA跟B
    2. 進入while結束條件是nodeA, B兩個都見底(next == null)
    3. 如果nodeCurrent見底，補一個空node上去
    4. 檢查nodeA, B本身還有沒有值，有就把值加在nodeCurrent.next上，然後next
    5. nodeCurrent做next，處理進位(有進位會在這時就補上新的next，所以3.那邊才要做檢查，如果3.不檢查直接新增會覆蓋這邊進位就新增的next
    6. 跑完while，return 回傳用的LinkedList.next(這裡會是next是因為第一個相加的node就是放在itCurrent.next上)
- 優化
    1. 建立一個sum，先將nodeA, B的合算在sum上再把sum當next串上去，這樣可以不做3.
    2. 串next時用sum%10然後再把sum/10留到下一輪迴圈累加這樣可以不做5.進位處理
    3. 如果你用了上面的方法，這樣可能會漏掉最後一次的進位所以迴圈結束要檢查sum有沒有值要不要串next

## #3_Longest Substring Without Repeating Characters
###### Related Topics: `Sliding Window`
### 目標
給一個字串s，找出最長不含重複字元的substring長度
### 求解
- 暴力法
    雙迴圈尋遍所有s[i]起點到s[j]終點的substring
- Sliding Window
    - 解釋
        定義兩個數str, end，0 <= str, end < array.Length and str <= end
        這樣會在陣列中形成一個窗，照條件縮放移動來掃描陣列，就能以單層迴圈搞定題目
    - 應用
        1. 宣告str, maxLength
        2. For迴圈，平常用的i作為end從0到s.Length - 1
        3. 求這次迴圈的窗戶長度 nowLength = end - str + 1
        4. 嘗試擴大窗戶，檢查這窗戶右邊一格的字元有沒有在窗內
            - 有，擴張失敗
                更新str位置到窗內重複字元的index + 1上，因為撞到這個重複的值後，再往右幾格這兩個重複的數字都會在窗內，所以str要直接跳過去來避免浪費
            - 沒，擴張成功
                嘗試更新看看nowLength有沒有比maxLength大
        5. 迴圈結束回傳maxLength

## #4_Median of Two Sorted Arrays
###### Related Topics: `Binary Search`
### 目標
給兩個int陣列nums1, nums2求兩陣列合併後的中位數(有序數列中間的數或兩數平均)
### 求解
- 暴力法
    C#可以宣告List，然後用addRange跟sort處理完直接算中位數，在LeetCode上的速度不會太差
- 符合O(log(m+n))的解
    1. nums1跟nums2合併得出的nums3，以中位數的位置切成兩半
    2. nums3的左半邊，會是由nums1用某點切割的左半邊與nums2用某點切割的左半邊組成的
    3. nums3的右半邊同理
    4. nums1[0,1,3] nums2[2,4,5] nums3[0,1,2,3,4,5] 
    5. nums1切點在1跟3之間；nums2在2跟4之間
    6. nums1, nums2的左半邊切點的值都會小於nums1, nums2右半切點的值
    7. 這時nums3左半的連接點會是nums1左半接點與nums2左半接點中較大的那個
    8. nums3右半的連接點會是nums1右半接點與nums2右半接點中較小的那個
    9. nums3數字數量是偶數那中位數就是兩接點的平均，奇數則會是其中一個接點(取決與你實作時左半多一格或右半多一格)
    10. 所以只要找到nums1, nums2的正確切割點這樣就可以求出中位數
    11. 因為切割點組出來的長度是可以求的(nums3.Length/2)，所以可以挑nums1的任一位置去推算nums2這時的切點在哪(nums1是長度較短的陣列，這樣搜尋比較快)
    12. 找切點的方式就是使用二元搜尋，當找到的位置可以符合6.就可以利用7.8.9.得出答案

## #5_Longest Palindromic Substring
###### Related Topics: `Dynamic Programming`、`Manacher's Algorithm`
### 目標
給一個字串s，求出最長的回文(字串左右對稱)subString
### 求解
- 暴力法
    雙迴圈尋遍所有s[i]起點到s[j]終點的substring
- 動態規劃
    1. 問題的最小情況，也就是最短的回文會是單個字元
    2. 問題的擴張，假設有i, j代表字串的頭尾，那從單個字元(i==j)往外擴張(i--, j++)，那s[i]還是會等於s[j]
    3. 所以可以藉由紀錄s[i]\~s[j]的狀況，遇到s[i-1]\~s[j+1]時檢查下面的條件來重複利用已經比對過的subString
        - s[i-1] == s[j+1] 
        - s[i]\~s[j]是不是回文
    4. 實作上可以用二維的bool陣列來紀錄，比較需要注意的是重複利用的部分是table[i+1, j-1]，所以雙迴圈掃描的那個方向要是可以先處理[i+1, j-1]這個位置的
- Manacher's Algorithm
    1. 中心擴展，以某字元為中心往左右擴張看尋找這個中心能產生的長回文。比如acbcd，以b為中心可以擴張一次得到cbc，然後回文半徑為1，這個半徑之後會用到
    2. 字串預先處理，在字串間(包含頭尾)插入符號，比如abbc→#a#b#b#c#，這樣的用意是偶數回文也可以用中心擴展找到，比如上面的#a#b#b#c#可以藉由最中間的#找到#b#b#這個回文，另一個用意是得到的半徑剛好會是回文的長度(去除符號)
    3. 鏡面特性，其實使用上面的方法就已經能夠解決題目，而這個演算法能比動態規劃還要快的原因就在這裡，下面的回文以c為中心左邊的半徑可以直接的貼到右邊而不用使用中心擴展
        |#|a|#|c|#|b|#|c|#|b|#|c|#|d|#|
        |-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
        |0|1|0|1|0|3|0|5|0|3|0|1|0|1|0|
        | | | |m| | | |c| | | |i| | |r|
    4. 不過這個特性還是有些限制，某些情況還是得用中心擴展來找半徑。實作上會有四個變數回文的中心c(cneter)、回文的右邊界r(right)、迴圈目前的進度i跟鏡面的m(mirror_i)跟存半徑的陣列r，綜合下面兩點會得出左半邊裡的子回文不能超出c位置回文的左邊界這個條件，也就是m-r[m]>c-r[c]
        1. i+r[m]超過r，因為不能確定r後面的部分能不能湊成回文或者有沒有超出陣列
        2. m, c位置為中心的回文左邊界在同一位置，因為i位置的那個回文可能會超出r
    5. c, r的更新，當目前位置的回文右邊界超出r就把這個位置當作新的c右邊界則是新的r，這是為了讓i保持在r的裡面
    6. 輸出，照上面的流程可以得到所有半徑(原字串回文長度)，而輸出需要知道這個回文在原字串的起點是哪裡，轉換方式是(index - r[index])/2，所以過程中更新最大長度時記得紀錄那個index

## #7_Reverse Integer
###### Related Topics: `Math`
### 目標
輸入一個int回傳反轉後的int，如果超出int則回傳0
### 求解
1. 取得尾數 x%10
2. 消除尾數 x/10
3. 檢查會不會益位
    - 正數，目前累加的值不能超過int.max/10，如果等於int.max/10那這輪的尾數不能大於7
    - 負數，目前累加的值不能小於int.min/10，如果等於int.min/10那這輪的尾數不能小於-8
4. 累加的數乘10在把這輪的尾數加上去

## #8_String to Integer
###### Related Topics: `String`
### 目標
給一個字串str轉換成數字
- 開頭的空白可以接受，欲到正負號或者數字後不行
- 數字間欲到其他字元就回傳目前截到的字串轉數字
- 益位回傳int.max或者int.min
### 求解
1. 第一次迴圈，遇到不是空白跳出，i會是數字起點
2. 檢查字串i是不是已經盡頭，是回傳0
3. 檢查str[i]是不是正負號，是的話i要再加一，然後正負號存起來(sign)
4. 第二次迴圈，遇到非數字跳出，j會是終點
5. 截出要轉換的字串str.subString(i, j - i)
6. 如果截出來的長度是0回傳0
7. try catch嘗試轉換sign+str.subString(i, j - i)
8. 如果catch就是益位，看sign來選擇回傳int.max或int.min

## #10_Regular Expression Matching
###### Related Topics: `Dynamic Programming`
### 目標
給一個字串s跟一個表達式p，回傳有沒有匹配
- s必定由a\~z組成或者是空字串
- p除了a-z還可能混入\*, .或者是空字串
- \*代表前面的字元會出現0\~n次
- .代表任一字元(a-z)
### 求解
1. 問題結構 子問題差別在於p的最後一個字元
    - 空字串對空字串 True
    - a-z 對比s, p兩個最後一字元之前的部分是否匹配跟最後一個有沒有匹配。例如ab跟ac\*b，最後字元之前的部分是a跟ac\*是匹配的，再來最後字元b跟b匹配
    - . 跟a-z一樣，不過最後一個字元不用比較，.本身可以是任何字元
    - \* 規則比較複雜，因為\*可以是0\~n個前一字元
        - 對比s本身跟p的最後兩個之前的部分，比如空字元跟a\*，那會用''跟''比對得到true；a跟ab\*會是用a跟a比對也是true
        - 另一個規則，你如果用abb跟ab\*套上面的規則會發現abb跟a不會匹配，但是實際上abb跟ab\*當然匹配。因為上面的規則只能用在\*前面的字元是零個的情況，如果不是零個那規則會是s最後一個字元之前的部分跟p本身比對，比如ab跟ab\*會是a跟ab\*比對，abb跟ab\*會是ab跟ab\*以此類推。
2. 應用，比對的結果用二維布林陣列儲存，意義是位置0\~n的s跟位置0\~m的p比對的結果
    - 陣列大小要是s.Length+1 \* p.Length+1，因為要包含空字串的部分
    - 初始化0, 0的位置要為True，s是空字串的部分可以先用單迴圈跑一次，因為只會出現\*的第一種情況，而要填完整個表的雙迴圈i, j都可以從1開始一路到Length
    - 因為i, j的跨度會到Lenth所以找字元的時候記得要減一才是平常操作字串的index
    - 最後回傳的值就是整個s, p的對比，也就是bool[s.Length, p.Length]

## #11_Container With Most Water
###### Related Topics: `Two Pointers`
### 目標
給一組n個正整數的int陣列，意義是指座標(0, a<sub>0</sub>)\~(i, a<sub>i</sub>)，然後每個座標會向下垂值到X軸上形成多條直線。任兩條直線會形成一個容器，容量是兩直線距離(底)\*較低的直線(高)，回傳最大容量
### 求解
1. 最理想的寬度是X座標0跟i
2. 但是也可能有最左右的直線很短中間的直線很長的情況
3. 所以尋找的途中有一邊會往另一邊逼近
4. 尋找最大可能，那逼近的那一邊就要挑目前比較矮的那一邊
5. 當兩邊距離重疊的時候結束迴圈
6. 回傳紀錄的最大值

## #13_Roman to Integer
###### Related Topics: `Math`、`String`
### 目標
輸入羅馬數字字串s回傳int
| I   | V   | X   | L   | C   | D   | M    |
| --- | --- | --- | --- | --- | --- | ---- |
| 1   | 5   | 10  | 50  | 100 | 500 | 1000 |
- I在V, X前代表4, 9
- X在L, C前代表40, 90
- C在D, M前代表400, 900
### 求解
1. 建立字元對數字的Dictionary
2. 宣告result, sameCharStr(一串相同字元的起點)
3. 迴圈，遇到s[i]!=s[i+1]就開始累加目前字元值\*(i-sameCharStr+1)
4. 相加完檢查s[i]是不是小於s[i+1]是的話要把上面的值\*2減回去才是正確結果
5. 重新定位sameCharStr為i+1
6. s[i]==s[i+1]就可以跳過不處理，因為要取i+1所以迴圈值能到s.Length-2，這樣迴圈結束後還要再做一次累加才可以回傳

## #14_Longest Common Prefix
###### Related Topics: `String`
### 目標
給一個string陣列strs，回傳最長的共同前綴
### 求解
1. 特例，陣列數量0值接回傳空字串；1則值接回傳唯一字串
2. 垂直搜尋，宣告length作為截取答案的長度跟搜尋的index
3. 每輪取strs[0][length]當比對字元，再來用比對strs[1]\~strs[strs.Length-1]
4. 這個過程用try catch包起來，如果有意外代表IndexOfRange，可以直接回傳任一字串的sub(0, length)

## #15_3Sum
###### Related Topics: `Hash Table`
### 目標
給一個int陣列nums找出所有3個數合為0的組合(不可重複)
### 求解
1. 從暴力法O(n<sup>3</sup>)降到O(n<sup>2</sup>)方式可以參考#1
2. 把nums排序成sortedNums
3. 把sortedNums數的後面放進Dictionary裡(sortedNUms[i], i)，Key重複跳過
4. 第一層迴圈的i決定可能組合的第一個數
    - 如果大於0那就可以中斷迴圈，因為除了0,0,0外的組合一定有正數有負數
    - 如果跟前面一個數一樣跳過避免重複
5. 內迴圈j開始就跟#1類似，不過Dictionary已經在上面建好了就不用每輪i迴圈重建
    - 如果跟前面一個數一樣跳過避免重複
    - x+y+z=0 → y+z=-x 所以可以把-x當成#1的target，那要找的目標就是-x-y
    - 如果Dictionary有-x-y這個Key而且對應的index比j大，那就是一個不重複的解。建立Dictionary要從後面來是避免0,0,0這樣的情況，i=0, j=1, index從前面數是0，從後面是2
    - 這裡不用Dictionary，用sortedNums.LastIndexOf也是一樣意思但是速度會差很多，是AC跟超時的差距

## #17_Letter Combinations of a Phone Number
###### Related Topics: `String`、`Backtracking`
### 目標
給一串由2\~9組成的字串digits，每個數可以對應3\~4個英文字母，回傳所有可能的英文字串
| 2   | 3   | 4   | 5   | 6   | 7    | 8   | 9    |
| --- | --- | --- | --- | --- | ---- | --- | ---- |
| abc | def | ghi | jkl | mno | pqrs | tuv | wxyz |
### 求解
1. digits長度0直接回傳空List
2. 建立數字對應英文的Dictionary
3. 先做一輪迴圈把第一個數字的對應放進List裡
4. 再來會做一個三層迴圈，第一層i是指digits的2\~Length的數字
5. 第二層j是指目前List有的數量，接下來每個element都回串上digits[i]的不同對應字母
6. 第三層k就是把element串上不同對應字母再加入List
7. 因為舊的element還是不完全的組合所以記得要移除，但是迴圈中移除element又加入新的進去會形成無窮，所以j的中止條件不能用List.Count而是要用變數存著當下的Count來當條件。再來是移除的另一個影響，下個j會指到的element會到0的位置，所以取值移除的index用0就好

## #19_Remove Nth Node From End of List
###### Related Topics: `Linked List`
### 目標
給一個LinkedList head跟n，把倒數第n個node移除再回傳回去
### 求解
- two pass: 先做一次搜尋得出head的長度，第二次就能確定要移除的node是哪個然後操作LinkedList達成目的
- one pass: 
    1. 宣告target(要移除的node)、preTarget、it(遍訪用的node)
    2. n的最小值會是List的長度不用擔心無解，假設it位在最後一個node上，那往前算n-1個就會是target要在的位置
    3. 一開始先做迴圈讓it前進n-1次，target設為head，之後讓target跟著it前移直到it到最後node的位置上，preTarget記得更新
    4. 如果preTarget是null代表n就是List長度，要移除的是head回傳head.next；否則把preTarget.next換成Target.next後回傳head

## #20_Valid Parentheses
###### Related Topics: `Stack`
### 目標
給一個由()、{}、[] 組成的字串s，回傳s裡的括弧是否都有匹配
### 求解
1. s.Length==0，回傳True
2. 把s[0]push進stack
3. 之後掃描2\~Length字元，跟peek的字元成對做pop，沒有做push
4. 結束後stack為空代表True

## #21_Merge Two Sorted Lists
###### Related Topics: `Linked List`
### 目標
合併兩個有序List a, b為一個有序List
### 求解
1. 宣告回傳ListNode result跟串接新node用的it
2. 第一次迴圈，a, b任一為空就結束，過程中取較小node的值當it的新next，it跟被取直的List做next
3. 第二、三次迴圈就是把a, b剩下的node接上去，最後回傳

## #22_Generate Parentheses
###### Related Topics: `Backtracking`
### 目標
給一個數n，回傳所有可能的n對括號擺法，例如3:
1. ((()))
2. (()())
3. (())()
4. ()(())
5. ()()()
### 求解
1. 因為能不能放置左括號或右括號有些條件限制，所以直接用迴圈產生會不太好寫，這邊使用遞迴
2. 遞迴需要的資訊
    - 傳址IList，回傳的是所有的組合，所以遞迴到任一解時要加入相同的容器中
    - 括號字串: current
    - 還可以擺放的左括號數量: l
    - 同上，右括號數量: r
3. 遞迴規則
    - 一開始current="", l=n, r=n
    - 當l, r都歸零代表括號擺放完，把current加入IList
    - 當l不為零，遞迴current+"(", l-1
    - 當右括號數量大於左括號，代表右括號放下去是有配對的，遞迴current+")", r-1

## #23_Merge k Sorted Lists
###### Related Topics: `Linked List`、`Heap`
### 目標
給k個有序List合併為一個有序List
### 求解
1. 這邊用使用MinHeap的解法，C#沒有內建這樣的容器，需要自己時做能Insert、Pop的MinHeap
2. 先把所有不為null的list insert進heap
3. 直到heap空為止，pop出來的node(temp)值當作回傳list的next，然後把temp的next再insert回heap

## #26_Remove Duplicates from Sorted Array
###### Related Topics: `Array`、`Two Point`
### 目標
給一個int陣列nums，求出不重複的數字數量n，然後把陣列前n個位置調整成那些不重複的數，例如[0,0,1,1,1,2,2,3,3,4]→[0,1,2,3,4,...]剩下的無所謂
### 求解
1. 如果是空陣列直接回傳0
2. 回傳值result預設為1
3. 迴圈比對nums[i]跟nums[i+1]，不同就把nums[result]的值設為nums[i+1]，因為result是目前不重複的數量，同時也可用當成不重複數值插進來的位置，之後result++
4. 結束後回傳result，伺服器那邊會比對nums的前result個值合不合要求

## #28_Implement strStr()
###### Related Topics: `String`、`Two Point`
### 目標
給兩個字串haystack, needle，求needle在haystack中出現的位置，例如hello, ll回傳2
### 求解
1. 迴圈比對的終點是i<=haystack.Lenght-needle.Length，在大needle會超出去
2. haystack.subString(i, needle.Length)跟needle相同就可以回傳i
3. 迴圈結束代表沒有對應回傳-1

## #29_Divide Two Integers
###### Related Topics: `Math`、`Binary Search`
### 目標
給被除數dividend跟除數divisor，回傳商。環境在bit32下，溢位回傳int.MaxValue(比如果int.MinValue/-1這樣會得到int.MaxValue+1這個值)。另外要求不使用*/%運算子
### 求解
1. 兩數相等回傳1
2. 被除數0或除數是int.MinValue(Min絕對值比Max還多1商必為0)，回傳0
3. 求商的正負號
4. 除數先套上絕對值(處理掉符號的bit)
6. 如果被除數是int.MinValue先做一次跟除數的相加，再套絕對值避免溢位(這步驟要紀錄是否發生)
7. 找商的核心: 被除數可以由數個除數\*2<sup>n</sup>相加再加餘數組成，例如87=7\*2<sup>3</sup>+7\*2<sup>2</sup>+3。其中2的部分總和就是商。實作上就是把2<sup>n</sup>找出來給被除數減直到被除數小於除數。
    1. 第一層迴圈，條件被除數大於等於除數，宣告一個temp設為除數，跟一個mul代表2<sup>n</sup>，進第二層迴圈找目標，出來後被除數減temp，mul累加
    2. 第二層迴圈，條件被除數大於等於temp<<1跟temp<<1大於0(數太大<<移位會產生負號，這時先跳出累加)，符合條件就讓temp跟mul<<
8. 出來後要先檢查5.有沒有發生還有累加結果是不是int.Max，都是再檢查商的正負號看是回傳Max或Min
9. 8.沒有就回傳正負號\*(累加+5.有發生累計1)