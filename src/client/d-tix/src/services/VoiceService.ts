export class VoieceService{
    private utterance: SpeechSynthesisUtterance;

    constructor(){
        this.utterance = new SpeechSynthesisUtterance();
        this.utterance.lang = "tr-TR";
        this.utterance.pitch = 1;    
        this.utterance.rate = 1; 
        this.utterance.volume = 0.6;
    }

    
    public get Speech() : SpeechSynthesisUtterance {
        return this.utterance;
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