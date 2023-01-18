# ChangingBallGame
update degisen top game : added animation, music etc aprowed uı .
Changing ball game enriched with animation and sound files, a unity project that takes the color of the collected balls and ends when the life is lost if the ball is matched with the same color ball.<br/>

ANIMASYON VESES EKLENTİSİ GELİŞTİRİLMİŞ GÖRSEL ARABİRİM . 

# OYUN AKIŞ 
ANA MENU ilk karşılama ekranı kayıtlı oyun yok (ilk kez oynanıyor) devam buttonu deaktif . Yeni oyun button  ile level1 sahnesine geçiş . 20 puan toplandıkdan sonra level2 ye (asekron ) geçiş . level2 de oyun bitince ana menu ye asekron  geçiş  . level1 veya level2 de ara menu ile oyun ekranından çıkılması durumunda ana menude devam buttonu ile toplanılan puandan devam edilir. Yeni oyun seçilirse puan sıfırlanır. 
Tüm sahne geçişleri asekron olarak tanımlandı .

# ANIMASYON VE SES DOSYALARI ENTEGRESİ
Spirete şeklinde buldugumuz görseller png formatında (arka planı temizlenerek)  unıty assetse eklendi . Unity 2D sprite editör ile sprite mod multiple olarak setlendi. açılan sprite editörde oynatılacak alanlar tek tek seçildi . Animasyonlar player üzerinde oynatıldığı için seçilerek animation içerisine spriteler atıldı ve animasyon oluşturuldu. animatorde boolen ifadelerle geçişler oluşturuldu. 
ses dosyaları wav fromatında assetse ekleni oyantılacak kısımlarda audio source komponenti eklendi ve ses dosyası buraya atandı.

 <br/><br/>
 ![anamenu](https://cdn-images-1.medium.com/max/900/1*Sqozhdwd1QaX9-qoCY1kBQ.png)
 # ANA MENU
 Oyuna ilk girişde ana menu sayfası bizleri karşılıyor  . Ana menude iki button var biri devam et digeri yeni oyun .
 **yeniden basla buttonu :**
 `public void ReStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }` 
    ile yeniden başla buttonuna tıklanınca kayıtlı skor  PlayerPrefs.DeleteAll ile  silinir ve  ana menu den sonraki level1 sahnesine asekron  geçiş current sahne GetActiveScen ile alınarak +1 yünlendiremsi ile sonraki sahneye geçiş   sağlandı.
    
    
 **Devam et** Buttonu önceden oynanan oyunun kaydedilen skorundan ve level inden itibaren oynamayı sağlıyor . oyun ilk kez oynandıgında kayıtlı  oyun olmadıgı için bu buttonun görünürlüğünü kapatıldı . 
  Kontrolu  kayıtlı oyunun skorunun 0 dan farklı olması durumunda true aksi durumda false return eden fonksiyonum ile `SetActive(false/true)` ile görünürlüğünü kontrol ettim.
 
Devam et buttonu görünür olunca tıklanması halinde `current scene` (nasıl alındıgından üstte bahsettim)e asekron yönlendirme yapıyor.
asekron sahne yönlendirmesi için  SceneManager dan  LoadSceneAsync fonksiyonuna sahne adı parametre verilerek geçiş oluşturuldu.



<br/>

  
 
  # ANIMASYON KONTORLLERI <br/>
  3 animasyon var <br/>
 **1** default animasyon sürekli oynamasını istediğimiz light animasyonu : loop aktif. üç farklı renkdeki ışık sprite ı loop a alınarak oluşturuldu  <br/>
  **2** bang anim blok çarpışma animasyonu : default state ile baglantısı bang true durumunda oynaması üzerine tasarladı loop deaktif edildi. toz efekti veren bir animasyon <br/>
  **3** succes toplarla eşleşmesi durumunda oynayan animasyon olarak tanımlandı : loop deaktif . fireworks şeklinde kutlama anımsyonu . <br/>
  **bang_anim sc**: 
BLOK İLE ÇARPIŞMA DURUMUNDA ÇARPIŞMA ANIMASYONU OYNATMA VE ÇARPIŞMA SESİNİN  OLUŞTURULMASI<br/>
`OnCollisionEnter` içerisinde blok teması kontrol edildi.
  my_bang_anim.SetBool("bang_true",true)  ile çarpışma animasyonu oynatıldı .  
  my_bang_source.Play();  ile çarpışma sesi oynatıldı.
  `OnCollisionExit`  içerisinde blok temsının bitiminde my_bang_anim.SetBool("bang_true",false) ile animasyon sonlandırıldı .
  
  
  # SES KONTOL VE TANIMLAMALARI<br/>
  3 ses mevcut <br/>
  **1** arka plan source : player camerasına ses verildi, sürekli oynamasını istediğimiz için loop aktif yapıldı .<br/>
  Her sahnede arka plan ses çalması için Awake fonk içerisinde  backSourceSC içerisine ` DontDestroyOnLoad(this.gameObject); ` ile sahne yüklenmelerinde sesin silinmesini engellendi.<br/>
 Sahne geçişlerinde aynı sahne birden fazla kez ziyaret edildiginde iki ses in oluşması oldu bu sorunu backSourceSC  null değilse ile destroy et şeklinde düzenlendi. <br/>
  **2** blok çaprışma sırasında çarpışma sesi bang_anim içerisinde kontorlu sağlandı. <br/> 
  **3** top toplama durumunda trik sesi (success) 
  PlayerCollisionControl içerisinde bang ve success seslerinin oynatılması yapıldı.
  PlayAudioClip parametre olarak aldıgı ses dosyasını  audioSource.Play(); ile oynatıyor. Bu fonk un çagrılması;
  OnCollisionEnter ile temas edilen obje kontrolu yapıldı ve oynatıcı fonksiyona ilgili ses dosyası parametre olarak verilerek oynatılması sağlandı.
  
  # LEVEL1 den  LEVEL2 SAHNE GEÇİŞİ İÇİN 
  ![level1](https://cdn-images-1.medium.com/max/900/1*Tk8YvrREy7hJPDsxeHF9pg.png)
player_sc içerisinde  void GoNextLevel()  fonk tanımlandı .  <br/>
Top toplama durumunda artan puan dan sonra puan kontrolu yapıldı if ile puanın 20 olması durumunda GoNextLevel() fonksiyonu çagrıldı . 
Bu koşul level1 den level2 ye geşiç koşulu --Level atlama
Level2 de puanım 20 olması halinde de bu fonksiyonun çalışması oldu yani level2 nin en başına dönüş sağladı. 
Bu sorunu if koşuluna ve ile level1 de oynanması koşulunu  eklendi . Bu sayede geçiş sadece level1 de puanın 20 olması durumunda level2 ye geçiş sağladı .
![level2](https://cdn-images-1.medium.com/max/900/1*Sqozhdwd1QaX9-qoCY1kBQ.png)
 <br/>
  LoadSceneAsync ile asekron bir geçiş oluşturuldu. <br/>
  SceneManager  dan .GetActiveScene ile aktif sahne elde edildi . (level1 sahnesi) + 1 ile sonraki sahneye geçiş tasarlandı . (level1 den sonraki sahne level2 dir)  <br/> <br/>

 # KAYIT ALMA
 playersc içerisinde playerPrebfs set iki parametre alıyor ilki name ikincisi ise değer int olan puanı tutmak için SetInt kullanıldı.
Kayıttan çekmek içinde aynı fonk un tek parametreli GetInt verisyonunu kullanıldı atadıgım deşişken ismi(skor ) ile çagırdı.
    <br/> <br/>
  # GAME OVER 
  Can bitmesi durumunda oyun bitiyor ve Asekron sahne geçişiyle ana menu ye geçiş sağlandı. <br/>
  
  ![default ana menu](https://cdn-images-1.medium.com/max/900/1*Tk8YvrREy7hJPDsxeHF9pg.png)
   <br/> <br/>
  # ARA MENU sc : 
  ARA MENUDE BUTTON ETKİLEŞİMİ İLE ANA MENUYE ASEKRON GEÇİŞ SAGLANDI<br/>
  goMainMenu fonk parametre olarak sahne adı alıyor unity uı dan bu sahneye asekron geçiş saglıyor .  <br/>
   <br/> <br/>
  # SKORE PANEL :
  level1 ve level2 sahnelerine yerleştirildi . <br/> 
  içerisinde iki tane uı elementi var button ve score text . <br/> 
  button aramenu buttonu ara menuye geçiş saglayan bir button . <br/> 
  TextMeshProUGUI komponentinden bir score text olusturdum içerisine playerprefbs deki set ile kaydettiğim değeri get ile çagırarak atama yapıldı .
  Get ile çektiğim veri bir int değişken ama atamak istediğim yer bir string burada int değeri toString ile string değişkene dönüşüm yapıldı. 
  
  <br/> <br/> 
   **Bu readme de  kendi yaptığım çalışmalardan bahsettim . Oyuna ait diğer bilgilere ekip arkaşımın reposundan ulaşabilirsiniz.**
   [irem atak repo](https://github.com/irematak/unity_3d_platform_oyunu-)
         
         


