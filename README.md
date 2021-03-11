{%hackmd theme-dark %}

# LeetCode 

###### tags: `LeetCode`

[![hackmd-github-sync-badge](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ/badge)](https://hackmd.io/NBIF1YT4QtmSJ3Ju1r4ljQ)

## #1_Two Sum 
###### Related Topics: `Array`、`Hash Table`
### 目標
給一個int陣列nums跟一個int target，nums當中會有兩個值合為target，且是唯一解
求那兩個值在nums中的index n, m，然後回傳int[] {n, m}
### 求解
- 查表法:
    nums[i] + nums[j] == taget → nums[j] == target - nums[i]
    尋找合為target的兩數這件是其實相當於尋找target減去nums某值得到的數X存不存在nums中，所以可以思考把nums的數存成一個Dictionary，key是數值value是對應的index，這樣可以在一層迴圈中一邊建表一邊搜尋X來把問題解決

## #2_Add Two Numbers
###### Related Topics: `Linked List`、`Math`、`Recursion`
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
###### Related Topics: `Hash Table`、`Two Pointers`、`String`、`Sliding Window`
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
###### Related Topics: `Array`、`Binary Search`、`Divide and Conquer`
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
###### Related Topics: `String`、`Dynamic Programming`
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
###### Related Topics: `Math`、`String`
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
###### Related Topics: `String`、`Dynamic Programming`、`Backtracking`
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
###### Related Topics: `Array`、`Two Pointers`
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
###### Related Topics: `Array`、`Two Pointers`
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
###### Related Topics: `String`、`Backtracking`、`Depth-first-Search`、`Recursion`
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
###### Related Topics: `Linked List`、`Two Pointers`
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
###### Related Topics: `String`、`Stack`
### 目標
給一個由()、{}、[] 組成的字串s，回傳s裡的括弧是否都有匹配
### 求解
1. s.Length==0，回傳True
2. 把s[0]push進stack
3. 之後掃描2\~Length字元，跟peek的字元成對做pop，沒有做push
4. 結束後stack為空代表True

## #21_Merge Two Sorted Lists
###### Related Topics: `Linked List`、`Resursion`
### 目標
合併兩個有序List a, b為一個有序List
### 求解
1. 宣告回傳ListNode result跟串接新node用的it
2. 第一次迴圈，a, b任一為空就結束，過程中取較小node的值當it的新next，it跟被取直的List做next
3. 第二、三次迴圈就是把a, b剩下的node接上去，最後回傳

## #22_Generate Parentheses
###### Related Topics: `String`、`Backtracking`
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
###### Related Topics: `Linked List`、`Divide and Conquer`、`Heap`
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
###### Related Topics: `Two Point`、`String`
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

## #33_Search in Rotated Sorted Array
###### Related Topics: `Array`、`Binary Search`
### 目標
給一個被轉動過的有序數列nums，比如[0,1,2,4,5,6,7]以index3為中心轉動後變為[4,5,6,7,0,1,2]，可以當成把前n數整組搬到數列後面接上。然後再給一個target求出它在數列中所在的index，如果不存在則輸出-1。
### 求解
如果是一般的有序數列可以直接使用二元搜尋解決，但是nums有序的部分因為轉動變為兩部分，所以需要先找出兩部分的分界點在哪，然後再對nums以分界點切開的前半段或後半段做二元搜尋找出target並回傳index。這邊將流程分為三部分: 
1. 找出分界點: 找的方法也是用二元搜尋，如果當下左右邊界中間切下去的位置，數值比右邊界的還大，那就代表這位置在分界點前面(觀察[4,5,6,7,0,1,2]，前半段最小的數會比後半段的任何數還大)，所以要更新左邊界到新位置來接近分界點，如果比右邊界的還小，則情況相反去更新右邊界到新位置，最後就能得出分界點。
2. 判斷target可能在前半段或後半段: 如果target比後半段的最大值(同時也是最後一個位置的值)還大，代表可能出現的位置會在前半段，較小則在後半段(觀察一下數列應該就能了解)。
3. 針對target可能出現的那部分做搜尋: 這裡就很單純了，target在前半段的情況做二元搜尋的左右邊界會是0跟分界點，後半段會是分界點跟陣列最後面。

## #34_Find First and Last Position of Element in Sorted Array
###### Related Topics: `Array`、`Binary Search`
### 目標
給一個漸增排序的數列nums，裡面的數字可能會重複比如[5,7,7,8,8,10]，再給一個target求出它在nums裡第一個跟最後一個出現的位置。回傳格式是兩格的int[]比如target8在[5,7,7,8,8,10]裡面的頭尾位置是[3, 4]，找不到則回傳[-1, -1]。
### 求解
直覺的想法是用二元搜尋去找出target所在的頭尾位置，不過這邊要稍微調整使用的方式，一般來說在迴圈的過程中找到target就會break/return，但是這裡我們要繼續跑下去，讓左右邊界相撞(也就是index相同)後再結束迴圈，最後一次符合target的位置將會是目標要的first或last。<br>
讓找的index是first或last的關鍵在於更新左右邊界的方式，如過這次要找的是first，要把右邊界更新的條件設為>=target(通常的二元搜尋會寫成>target)，這樣子重複找到的target會讓右邊界慢慢往左(因為等於target也要左移)，最後一次找到target的index就會是first。找last的概念也一樣，將左邊界條件改為<=target，做完這兩次二元搜尋後的first跟last就會是題目所要的。

## #36_Valid Sudoku
###### Related Topics: `Hash Table`
### 目標
給一個char的二位陣列代表一個數獨，然後去檢查這個數獨有沒有符合規則(每行、每列、每個小九宮格都不能有重複的數字)。
### 求解
直覺的想法是一邊掃描(雙for迴圈)數獨一邊檢查有沒有違規(能掃完代表整格合法)，這邊可以根據規則分別建立儲存列、行、小九宮格用的容器(List)，當新掃到的元素跟容器內的有產生重複就代表違規了。<br>
問題在於容器的形式，這個又跟掃描的方式有點關係，假設內迴圈代表掃描列那列可以用一個單純的List就好(內迴圈做完記得清空)；行的部分因為是用外迴圈更新所以一次內迴圈做完的當下還不會有整行的內容，所以紀錄行的List要宣告成大小9的List陣列來保留列的內容；小九宮格跟行同理，也是沒辦法再做完內迴圈的當下知道，要圈告成3*3的List陣列。<br>
釐清儲存的方式後就是檢查的時機了，在內迴圈裡找到新元素時對三種List檢查有沒有Contains就好。

## #38_Count and Say
###### Related Topics: `String`
### 目標
say是一種會產生字串的行為。預設的字串為"1"，也就是第一次say會產生"1"，之後的say則會開始照規則產生新字串，舉例來說3322251這字串，因為2個3、3個2、1個5跟1個1，所以新字串是23321511。<br>
題目會給一個n，回傳say n次後得到的字串。
### 求解
流程很簡單，照從"1"開始照規則造字串n次就行。所以會有個外迴圈跑n次，迴圈內分析當下的say字串有幾個數字a、數字b、數字c...，然後把各別的次數跟對應的a、b、c...串起來後更新say，下次的迴圈再用新的say去做更新的say。

## #41_First Missing Positive
###### Related Topics: `Array`
### 目標
給一個無序整數數列nums，找到第一個缺少的正整數。比如[3,4,-1,1]缺少的是2。
### 求解
直覺的想法是將nums排序後做掃描來找目標，比如[4,1,2]排序完變[1,2,4]，之後發現2後面不是3來找到缺失的數是3，觀察[1,2,4]會發現nums內容會跟index差不多，index0是1、index1是2，再來index2是4剛好就是答案，所以可以得出結論: 從index0開始判斷，如果nums[index]-1!=index那這個index原本應該要對應的數(index+1)會是答案。<br>
接下來的問題是如和把[4,1,2]轉為[1,2,4]，考慮到可能有小於1的情況值接排序是不可行的，這裡可以利用index，以迴圈遍歷nums遇到1就把1放到index0、2則放到index1這樣以此類推，遇到小於1或值太大會造成index越界的情況就跳過，之後再掃描數列遇到nums[index]-1!=index那index+1就是答案，因為這代表遍歷的過程並沒有找到對應的數，那個位置內容自然不會跟index有對應。

## #42_Trapping Rain Water
###### Related Topics: `Array`、`Two Pointers`、`Dynamic Programming`、`Stack`
### 目標
給一個非負數列height代表地形高度，而地形之間形成的凹洞可以積水，求出height可以累積的水量。
### 求解
首先要知道求出每格位置能累積的水的方法，以題目範例圖來說height[4]可以積的水是1，這是因為這個位置左右最高的地形分別是2跟3，然後取較矮高度2再減去自身高度1來得出1，結論某位置a的水量會是min(maxL, maxR)-height[a]。<br>
接下來的問題是如何去跑遍歷height去累計全部位置的積水，這題可以從暴力法開始再改善成DP最後變雙指針:<br> 
1. 暴力法: 計算每格積水時都去找一次maxL、maxR來計算，但是要找的值有時會重複，所以可以改成DP。
2. DP: 用兩個陣列(左右各一)去記住當下位置的maxL、maxR，之後計算值接從陣列拉值就好。那要怎麼得出這兩個陣列呢?以左邊來說，height[0]最高會是自己因為再左邊就沒東西了，之後從index1開始遍歷height，去比較現在位置跟前個位置哪個比較高然後放進陣列裡就可以了，右邊同理。
3. 雙指針: 用兩個指針(l、r)代表目前指到的位置、兩個數(maxL、maxR)紀錄目前左右最高的值，如果maxL較小那就累計水量maxL-height[l](這邊不用擔心右邊資訊不完整的問題，因為計算上就是用較小的那邊來算)，之後嘗試更新maxL、l指針往右逼近。如果是maxR較小那同理，用maxR、height[r]計算，算完更新maxR、r往左逼值，這個過程持續到l、r撞上為止，累計的水量就是答案。

## #44_Wildcard Matching
###### Related Topics: `String`、`Dynamic Programming`、`Backtracking`、`Greedy`
### 目標
這題跟#10有87%像，只是pattern的定義有些差別。給兩個字串s、p，s是由a~z組成的字串，p則是除a~z外還會參雜?(任何單一字母)、\*(任何長度的字串)的表達式，然後求s有沒有符合p。<br>
### 求解
1. 問題結構: 根據p的字元可能情況有4種
    1. 空字串: 如過s也是空字串那就是true，不是一律都是false
    2. a~Z: s、p都是單一字元的情況就單純看兩個字元是否相同，當問題變大時(s、p都有多個字元)先比對兩者最後的字元是否相同，再去看兩者最後字元以前的部分是否匹配
    3. ?: 跟字母的情況一樣，只是單一字元不用比一定對
    4. \*: 情況有兩種，如果\*對應過去會代表空字串，比如s: aa、p: aa\*，那會用p在\*之前的部分跟整個s比對(aa對aa)；如果有代表一串數，比如s: axyz、p: a*，則是用s排除最後一個字元的字串跟p比對會是axy對a*，看到這邊會想這不是跟前一次的狀況一樣嗎?先倒過來想從ax比a\*開始會是a對a\*，這樣就回到\*代表空字串的情境所以確定它是對的，往後推axy比a\*會是ax對a\*，因為前一次已經確認過了所以這次也能確定它是對的，以此類推axyz跟a\*就會是匹配的
2. 應用: 這邊就很直覺的用二維布林陣列(dp[,])代表i長度的s跟j長度的p是否匹配，因為要含空字串情況所以陣列長度要是字串長度加一。注意預設值dp[0,0]為true，還有p開頭就是一串\*的情況也要先刷進去，填表完後dp[s.Length,p.Length]就是答案。

## #46_Permutations
###### Related Topics: `Backtracking`
### 目標
給一個數列nums，求出所有元素排列的可能(這些可能的順序不影響結果)，例如nums[1,2,3]的可能排序為[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]。
### 求解
這裡可以用遞迴去做，傳遞的參數有三個: nums剩下的元素(restElement)、正在組成某個排序的數列(current)與紀錄答案的容器(result)。每次的遞迴都會遍歷restElement，把某個元素restElement[i]拔掉並串在current後面，然後再遞迴值到restElement空了為止，這時的current就能加進result。這裡要注意處理restElement、current要用複製的一份資料來作，不然遍歷的過程中restElement、current都會被打亂。

## #48_Rotate Image
###### Related Topics: `array`
### 目標
給一個二維陣列來代表一個矩陣，把矩陣順時針旋轉90度後回傳。只能修改題目給的矩陣而不能開心的陣列來處理。
### 求解
解題的關鍵就在迴圈怎麼跑可以讓元素的交換形成題目要的旋轉。方式有兩種，這邊講過程比較值觀的一種(兩種都可以再Solution那邊看)，以左上右下的斜線當軸互換元素一次，再左右水平翻轉元素一次就會等於順時針旋轉90度一次。

## #49_Group Anagrams
###### Related Topics: `Hash Table`、`String`
### 目標
給一個string陣列代表，把裡面的字串分類成各種anagrams(組成的元素相同但順序不一樣比如: ate、eat、tea)。
### 求解
收先要先知道分類的方式，再去作歸類的動作，這邊分兩步驟: 
1. 兩字串是否為同類anagrams: 組成的元素相同代表排序完後會一模一樣，至於排序的方法可以將string先轉為array，再用Array.sort()排完再轉回string
2. 如何歸類: 這裡用Dictionary來當容器，key是排序完的字串，value則是一個List，如果這次排序完的字串有被containsKey那就丟進那個key的List裡，沒有就開一個新key並把這個字串丟進去，最後把Dictionary組回題目要的格式就行了

## #50_Pow(x, n)
###### Related Topics: `Math`、`Binary Search`
### 目標
給一個浮點數x跟整數n，求x的n次方
### 求解
最簡單的方式是x直接乘上n次，但顯然會讓速度變慢。這裡可以利用"所有數可由2\^a+2\^b+2\^c...組成"的這個特性，例如10=2\^3+2\^1、5=2\^2+2\^0，然後會發現相加的這些2的指數會符合二進制為1的部分，10=1010、5=101(應該說這本來就是十進制跟二進制轉換用的技巧)。另個會用到的就是指數的運作規則，假設a+b=c，x\^c=x\^a\*x\^b。<br>
這件事能運用在n上面，假設要算3\^10，根據上面的說明會計算3\^8\*3\^2，而這兩個東西怎麼來?弄個迴圈開始跑，過程中讓x一直跟自己相乘就會得到3\^(1、2、4、8...)，然後檢查n是不是奇數(代表二進制為1的部分也就是2或8)，是就把目前的x拿來跟答案的變數(初始為1)相乘，每次迴圈結束把n/2直到n變0結束。

## #53_Maximum Subarray
###### Related Topics: `Array`、`Divide and Conquer`、`Dynamic Programming`
### 目標
給一個整數數列nums，求出最大的子數列總和。
### 求解
需要關注的問題很簡單，如果nums[i]跟前面的數(nums[i-1])相加會變大就把這個結果更新進nums[i]裡面，再下個nums[i]也去這樣檢查，遍歷玩nums後每個內容就會變成當下位置跟前面幾個數形成的子數列最大值，當然也可能內容不變(代表前面的總和是負數不如不要累加過來，自己一個就是這位置最大總合)，然後nums裡最大的值就是最大子數列總合(在遍歷的過程中更新變數也行)。

## #54_Spiral Matrix
###### Related Topics: `Array`
### 目標
給一個n\*m的陣列，用順時針螺旋的方式依序把元素丟進容器裡後回傳那個容器。
### 求解
螺旋探索沒很複雜，建立代表上下左右邊界的變數，然後把目前邊界最外圈的元素丟進容器裡，接下來把邊界往內縮，重複這兩個動作直到邊界撞上為止。需要注意的是右下到左下、左下到左上的探索不能在邊界相等時做，會造成元素重複抓進容器裡。所謂邊界相等就是最後一圈上下或左右的長度只有1的情況。

## #55_Jump Game
###### Related Topics: `Array`、`Greedy`
### 目標
給一個非負整數數列nums，每個位置代表能夠往前跳的量，求出nums是否能從index0開始跳到最後一個位置，比如[2,3,1,1,4]: index0可以跳到index1或2，index1可以跳到index4(最後)，所以給過；又比如[3,2,1,0,4]: index0可以跳到index1、2或3，但是接下來這三個位置最終都只能在index3止步，所以不給過。
### 求解
這題可用貪婪法得最佳解(另兩種是用遞迴探索所有可能性、改良遞迴變動態規劃)，用一個數去紀錄當下可以跳得最遠距離(maxIndex)，接下來遍歷nums，如果現在這位置的index比maxIndex大可以直接判定失敗，因為能跳到的最遠距離到不了這個點，如果能到則去嘗試更新maxIndex(現在位置加上這位置能跳的距離所得的index比maxIndex大就更新)，能遍歷完代表最後一個位置也沒發生會判定失敗的情形給過。

## #56_Merge Intervals
###### Related Topics: `Array`、`Sort`
### 目標
給好幾組間距合併有相疊的組合，比如[[1,3],[2,6],[8,10],[15,18]]: [1,3]、[2,6]因為3跨過2所以這兩組能合併成[1,6]，接下來的[8,10]、[15,18]則都沒有相疊，最後輸出[[1,6],[8,10],[15,18]]。
### 求解
首先，相疊的條件式結尾大於等於其他組的開頭，所以可以從某組開始往後搜尋符合條件的組合並更新結尾的數值(例如例子裡[1,3]原本結尾3，後來因為合併[2,6]結尾變6，這樣代表可以合併其他更多組合)。<br>
因為題目給的組合是不排序的，所以可能會有[0,1],[2,4],[0,3]這樣漏掉[2,4]的情形，因此要先做以開頭為基準的排序，需要實作IComparer。<br>
還有遍歷的方式通常是雙迴圈(外抓某組當基準，內以基準嘗試合併其他組)，當內迴圈以經判斷是能合併的組合，那外迴圈可以跳過這些組合，也就是內迴圈跑完可以把j指定給i(code中-1是因為要跟for的i++抵銷)

## #62_Unique Paths
###### Related Topics: `Array`、`Dynamic Programming`
### 目標
給m、n兩個數代表網格的長寬，放一台機器人從左上開始走到右下，只能往右或往下。試問有幾走可行的路線。比如3\*2的網格有右下下、下下右、下右下3種路線。
### 求解
右下角有幾種路線可以用上面跟左邊的可能性相加來得出，再往前推那兩格也能由上面跟左邊的可能性相加來得出，這樣推到底就會回到左上角。<br>
根據上面的說明可以得到兩件事，某格的路線數量是由左邊跟上面的路線數量總合、右下角可以推回左上角，那從左上角就能算到右下角。需要注意的是最上面的那列跟最左邊那行要做出始化(1)，不然會越界。

## #66_Plus One
###### Related Topics: `Array`
### 目標
給一個非負數列代表一個整數，比如[1,2,3]代表123，求出這個整數加一同樣以陣列方式回傳。
### 求解
流程很單純，將數列最後一個位置加一，然後處理進位。需要注意的是如果第一個位置也需要進位(比如999+1)，那要新增一個比原陣列長一格的陣列把舊數列移進來讓開頭的數進位。

## #69_Sqrt(x)
###### Related Topics: `Math`、`Binary Search`
### 目標
求出x的平方根，不要求小數點只要整數部分即可。
### 求解
用二元搜尋的方式去找，右邊界可以直接從x/2開始(平方根一定不會超過自己的一半)，過程判斷左右邊界中間切下去的值mid，mid是平方根有兩種情況，x的平方根剛好是整數(mid\^2=x)或者mid\^2<x同時(mid+1)\^2>x代表x的平方根是mid帶一串小數一樣是答案。如果都不符合就根據mid\^2大於小於x去更新左右邊界，因為l初始為1、r初始為x/2所以x是0、1的時候會直接略過迴圈，因此預設的回傳要是x(0、1的平方根都是自己)。

## #70_Climbing Stairs
###### Related Topics: `Dynamic Programming`
### 目標
給一個n代表階梯的高度，從第1階開始爬，一次可以爬1或2階，求出爬到n階有幾種爬法。比如3階可以有1+1+1、1+2、2+1這3種爬法。
### 求解
因為有1、2兩種前進的選擇，所以n階的組合其實就是前兩階的組合相加，第1階跟第2階預設是1跟2(因為這兩階沒有前兩階可以相加)。<br>
實作的方式直覺的dp會開陣列去跑，但是這裡會重複用到的資料也就前兩個數而已，所以可以開3個變數a、b、c去代表前2階、前1階、這一階。因為第1階、第2階是預設所以迴圈可以從第3階開始跑，c的預設可以先訂為n，這樣n是1、2時會跳過迴圈回傳自己。(一階、二階的組合就是1、2)。

## #73_Set Matrix Zeroes
###### Related Topics: `Array`
### 目標
給一個m\*n的矩陣，如果某個位置matrix[i,j]=0，那麼把同個行、列的位置都設為0。
### 求解
可以將第一行跟第一列做為標記區，如果某個位置為0就把最左方(第一行)跟最上方(第一列)也標記為0。標記完後再掃描一次矩陣如果對應的標記位置是0那就把這位置設為0。<br>
需要注意的是處理標記時第一行的標記要用bool紀錄而不是直接設定標記(直接標會導致[0,0]可能被標上讓後面的處理錯誤)；後面開始設置0的處理標記區也要另外做，如果[0,0]=0代表第一列有0(先撇除本來就為0的情況)，所以第一列就能放心全設為0。第一行的部分則看之前紀錄的那個bool；這兩者順序不能對調，如果第一行先做[0,0]就有機會先被設為0影響第一列的正確性。

## #75_Sort Colors
###### Related Topics: `Array`、`Two Pointers`、`Sort`
### 目標
給一個數列nums代表一串顏色(0: 紅、1: 白、2: 藍)，把這些顏色排序。本質上就是一串由0、1、2組成的數列(可能會重複)，然後做排序。
### 求解
開個陣列儲存各種顏色的頻率，之後依序從0\~2依照出現的次數開始填回nums裡這樣一樣會有排序的效果。

## #76_Minimum Window Substring
###### Related Topics: `Hash Table`、`Two Pointers`、`String`、`Sliding Window`
### 目標
給兩個字串s、t，找出包含t所有字元的最短的s子字串，比如s: "ADOBECODEBANC"、t: "ABC"，符合的子字串有"ADOBEC"、"BECODEBA"、"CODEBA"、"BANC"，最短的是"BANC"。
### 求解
先制定一下解題的流程，第一件事是尋找符合的解、第二件事是嘗試尋找更好的解。
1. 尋找解: 使用兩個陣列，一個先初始化成t個每個字元出現的頻率(char會自動轉為ASCII當Index用)，另一個則在掃瞄s時紀錄跟t某個字元有重複的字元的頻率，這樣當兩陣列內容相同時就代表找到符合的解。接下來的課題則是如何知道兩陣列內容相同，直覺的方式是走一遍迴圈逐個比較。但還有更快的方式，當s這側的頻率小於等於t側時就累加一個count(大於代表超出t那邊的量沒有累加的必要)，這樣count=t.Length時就代表可能解。
2. 嘗試尋找更佳解: 這題運用窗的地方就在這，右邊界本來就會依據迴圈往右跑，左邊界的部分則要另外更新。當出現可能解時(count=t.Length)要更新左邊界，更新的情況有兩種: 現在左邊界位置在跟t沒關係的字元上那就直接讓左邊界右移一格、左邊界位置上的字元，s側頻率比t側高代表這個字元捨棄後兩個陣列紀錄的頻率還是能對上，把這字元的頻率降一然後一樣左邊界右移一格；接下來就是把左右邊界形成的子字串跟現在紀錄的解比較長短嘗試更新。

## #Num_ProblemName
###### Related Topics: `tag`
### 目標
### 求解