export class VoieceService{
    textToSepach(text: string): void {
        if ('speechSynthesis' in window) {
            const utterance = new SpeechSynthesisUtterance(text); 
            utterance.lang = "tr-TR";
            utterance.pitch = 0.2;    
            utterance.rate = 0.8;  
            window.speechSynthesis.speak(utterance); 
        } else {
            console.error("Tarayıcınız metin seslendirme özelliğini desteklemiyor.");
        }
    }
}