import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';


const d_tix_theme = {
    dark: true, 
    colors: {
        background: '#121212', // Genel arka plan rengi
        surface: '#1E1E1E', // Kartlar ve diğer yüzeyler için arka plan
        primary: '#BB86FC', // Vurgulayıcı ana renk
        secondary: '#03DAC6', // İkincil vurgu rengi
        accent: '#FF4081', // Öne çıkan vurgu rengi
        error: '#CF6679', // Hata mesajları ve hatalar için kırmızı
        info: '#2196F3', // Bilgi mesajları için mavi
        success: '#4CAF50', // Başarı mesajları için yeşil
        warning: '#FB8C00', // Uyarılar için turuncu
    },
    variables: {
        'border-color': '#FFFFFF', // Beyaz kenar rengi
        'border-opacity': 0.12, // Kenar şeffaflığı
        'high-emphasis-opacity': 0.87, // Yüksek vurgu opaklığı (Örneğin ana metinler)
        'medium-emphasis-opacity': 0.60, // Orta vurgu opaklığı (İkincil metinler)
        'disabled-opacity': 0.38, // Pasif ve devre dışı öğeler için şeffaflık
        'idle-opacity': 0.04, // Bekleyen durumdaki öğelerin şeffaflığı
        'hover-opacity': 0.08, // Üzerine gelindiğinde uygulanacak şeffaflık
        'focus-opacity': 0.12, // Odaklanıldığında uygulanacak şeffaflık
        'selected-opacity': 0.16, // Seçilen öğeler için şeffaflık
        'activated-opacity': 0.24, // Etkin öğeler için şeffaflık
        'pressed-opacity': 0.32, // Basıldığında uygulanacak şeffaflık
        'dragged-opacity': 0.08, // Sürüklenen öğeler için şeffaflık
        'theme-kbd': '#3C4043', // Koyu gri klavye arka planı
        'theme-on-kbd': '#E0E0E0', // Klavye tuşlarındaki metin için açık gri
        'theme-code': '#1E1E1E', // Kod blokları için koyu gri arka plan
        'theme-on-code': '#F5F5F5', // Kod blokları üzerindeki metinler için açık beyaz
      }
};

const vuetify = createVuetify({
    components,
    directives,
    theme:{
        defaultTheme: 'd_tix_theme',
        themes: {
            d_tix_theme
        }
    }

});


export default vuetify;