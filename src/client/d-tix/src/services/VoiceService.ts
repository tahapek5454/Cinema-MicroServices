declare const webkitSpeechRecognition: any;


export class VoieceService{
    private utterance: SpeechSynthesisUtterance;
    private  recognition : typeof webkitSpeechRecognition;
 
    constructor(){
        // text to speech
        this.utterance = new SpeechSynthesisUtterance();
        this.utterance.lang = "tr-TR";
        this.utterance.pitch = 1;    
        this.utterance.rate = 1; 
        this.utterance.volume = 0.6;

        // speech to text
        if('webkitSpeechRecognition' in window){
            this.recognition = new webkitSpeechRecognition();
            this.recognition.lang = 'tr-TR'; 
            this.recognition.continuous = false; 
            this.recognition.interimResults = false; 
        }else{
            this.recognition = null;
        }
    }

    
    public get Speech() : SpeechSynthesisUtterance {
        return this.utterance;
    }

    public get Recognition() : typeof webkitSpeechRecognition{
        return this.recognition;
    }

    textToSpeech(text: string): void {
        if(!text) return;
        if ('speechSynthesis' in window) {
            this.utterance.text = text;
            window.speechSynthesis.speak(this.utterance); 
        } else {
            console.error("Tarayıcınız metin seslendirme özelliğini desteklemiyor.");
        }
    }
    cancelTextToSpeech(): void {
        if ('speechSynthesis' in window) {
            window.speechSynthesis.cancel();
        } else {
            console.error("Tarayıcınız metin seslendirme özelliğini desteklemiyor.");
        }
    }
}