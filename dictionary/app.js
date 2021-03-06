const findDefinition = function() {
    clearPage();
    const word = $('#wordInput').val();
    $.get(
        `https://www.dictionaryapi.com/api/v3/references/collegiate/json/${word}?key=4c55cdcb-15dd-4fd3-a1ab-705f453bb6a6`,
        function(data) {
            data === "Word is required" ? 
                $('#definitions').append('<h3>Definitions</h3>')
                : null;
            for(let d of data) {
                if(d.shortdef !== undefined) {
                    for(let def of d.shortdef) {
                        $('#definitions').append(`<p class="definition">${d.hwi.hw} <em>${d.fl}</em>: ${def}</p>`);
                    }
                }
            }

            data[0] ? 
                $('#audio').append(`
                <h3>Pronunciation</h3>
                    <audio controls>
                        <source src=${getAudio(data[0].hwi.prs[0].sound.audio)} type="audio/mpeg">
                    </audio>`)
                : null;
        }
    )
}

const pronounceWord = function(word) {
    const msg = new SpeechSynthesisUtterance();
    const voices = window.speechSynthesis.getVoices();
    msg.voice = voices[10]; 
    msg.text = word;
    msg.volume = 1;
    msg.rate = 1;
    msg.pitch = 2;
    msg.lang = "en";
    window.speechSynthesis.speak(msg);
}

/* [subdirectory] is determined as follows:
if audio begins with "bix", the subdirectory should be "bix",
if audio begins with "gg", the subdirectory should be "gg",
if audio begins with a number or punctuation (eg, "_"), the subdirectory should be "number",
otherwise, the subdirectory is equal to the first letter of audio.
[base filename] - The name contained in audio. */

const getAudio = function(audio) {
    let subdirectory;
    if(audio.substring(0,3) === 'bix') subdirectory = 'bix';
    else if(audio.substring(0, 2) === 'gg') subdirectory = 'gg';
    else if(audio.match(/^[!"\#$%&'()*+,\-./:;<=>?@\[\\\]^_‘{|}~]|^\d/g)) subdirectory = 'number';
    else subdirectory = audio.substring(0, 1);
    return `https://media.merriam-webster.com/audio/prons/en/us/mp3/${subdirectory}/${audio}.mp3`;
}

const getSynonyms = function() {
    clearPage();
    const word = $('#wordInput').val();
    $.get(`https://www.dictionaryapi.com/api/v3/references/thesaurus/json/${word}?key=57767602-af3e-4339-83c2-3f146afc71af`,
    function(data) {
        $('#synonyms').prepend('<h3>Synonyms</h3>');
        $('#antonyms').prepend('<h3>Antonyms</h3>');
        for(let obj of data) {
            if(obj.hwi.hw === word) {
                for(let syns of obj.meta.syns) {
                    syns.forEach(syn => {
                        $('#synonymList').append(`<li>${syn}</li>`)
                    });
                }
                for(let ants of obj.meta.ants) {
                    ants.forEach(ant => {
                        $('#antList').append(`<li>${ant}</li>`)
                    });
                }
            }
        }
    })
}

const clearPage = function() {
    $('#definitions').empty();
    $('#synonymList').empty();
    $('#antList').empty();
    $('h3').remove();
    $('#audio').empty();
}