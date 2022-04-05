function FunctionOpen(id1, id2, id3) {
    var x = document.getElementById(id1);
    document.getElementById('hamburger').style.display = 'none';
    document.getElementById('cross').style.display = 'block';

    if (x.style.display === "none") {

        x.style.display = "block";

    } else {
        x.style.display = "none";
    }
    return false;
}
function FunctionClose(id1, id2, id3) {
    var x = document.getElementById(id1).style.display = 'none';

    document.getElementById('hamburger').style.display = 'block';
    document.getElementById('cross').style.display = 'none';

}


// Web Cam Video Recording and Save to Server
function StartRecordingWebCam() {
let mediaRecorder;
let recordedBlobs;

const errorMsgElement = document.querySelector('span#errorMsg');
    const recordedVideo = document.querySelector('video#recorded');
    const startVideo = document.querySelector('video#gum');

const recordButton = document.querySelector('button#record');
const shareButton = document.querySelector('button#share');
const downloadButton = document.querySelector('button#download');
    const saveButton = document.querySelector('button#save');
    const pauseButton = document.querySelector('button#pause');
    const stopButton = document.querySelector('button#end');

    stopButton.addEventListener('click', () => {
        debugger
        stopRecording();
        
    });

    pauseButton.addEventListener('click', () => {
        debugger
        if (pauseButton.textContent == "Pause") {
            pauseRecording();
        }
        else {
            resumeRecording();
        }
        

    });


downloadButton.addEventListener('click', () => {
    debugger;
    const blob = new Blob(recordedBlobs, { type: 'video/mp4' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = 'test.mp4';
    document.body.appendChild(a);
    a.click();
    setTimeout(() => {
        document.body.removeChild(a);
        window.URL.revokeObjectURL(url);
    }, 100);
});
saveButton.addEventListener('click', () => {
        debugger;
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = mm + '-' + dd + '-' + yyyy;

    var formData = new FormData();
    var fileName = today + "_"+ (Math.random() * 10000) + "_blob.mp4";


    var encodeData = new Blob(recordedBlobs, { type: 'multipart/form-data' });
    formData.append("blob", encodeData, fileName);

    var request = new XMLHttpRequest();
    request.open("POST", "http://localhost:5002/api/UploadWebCamVideo/UploadVideo", false);
    request.send(formData);

    });

function handleDataAvailable(event) {
    debugger;
    console.log('handleDataAvailable', event);
    if (event.data && event.data.size > 0) {
        recordedBlobs.push(event.data);
    }
}

function startRecording() {
    debugger;
    recordedBlobs = [];
    let options = { mimeType: 'video/webm;codecs=vp9,opus' };
    try {
        mediaRecorder = new MediaRecorder(window.stream, options);
    } catch (e) {
        console.error('Exception while creating MediaRecorder:', e);
        errorMsgElement.innerHTML = `Exception while creating MediaRecorder: ${JSON.stringify(e)}`;
        return;
    }

    console.log('Created MediaRecorder', mediaRecorder, 'with options', options);
    mediaRecorder.onstop = (event) => {
        console.log('Recorder stopped: ', event);
        console.log('Recorded Blobs: ', recordedBlobs);
        saveButton.style.display = "inline";

        downloadButton.style.display = "inline";

        shareButton.style.display = "inline";
        startVideo.style.display = "none";
        recordedVideo.style.display = "block";
        const superBuffer = new Blob(recordedBlobs, { type: 'video/webm' });
        recordedVideo.src = null;
        recordedVideo.srcObject = null;
        recordedVideo.src = window.URL.createObjectURL(superBuffer);
        recordedVideo.controls = true;
        recordedVideo.play();
    };
    mediaRecorder.ondataavailable = handleDataAvailable;
    mediaRecorder.start();
    console.log('MediaRecorder started', mediaRecorder);
}

function stopRecording() {
    debugger;
    mediaRecorder.stop();
    
    }

    function resumeRecording() {
        debugger;
        pauseButton.textContent = "Pause";
        mediaRecorder.play();

    }

    function pauseRecording() {
        mediaRecorder.pause();
        pauseButton.textContent = "Resume"
    }

function handleSuccess(stream) {
    debugger;
    startVideo.style.display = "block";
    console.log('getUserMedia() got stream:', stream);
    window.stream = stream;

    const gumVideo = document.querySelector('video#gum');
    gumVideo.srcObject = stream;

    if (recordButton.textContent === 'Record') {
        startRecording();
    }
}

async function init(constraints) {
    debugger;
    try {
        const stream = await navigator.mediaDevices.getUserMedia(constraints);
        handleSuccess(stream);
    } catch (e) {
        console.error('navigator.getUserMedia error:', e);
        errorMsgElement.innerHTML = `navigator.getUserMedia error:${e.toString()}`;
    }
}


    
    document.querySelector('button#record').addEventListener('click', async () => {
        debugger;
        startVideo.style.display = "block";
        const hasEchoCancellation = document.querySelector('#echoCancellation').checked;
        const constraints = {
            audio: {
                echoCancellation: { exact: hasEchoCancellation }
            },
            video: {
                width: 1280, height: 720
            }
        };
        console.log('Using media constraints:', constraints);
        await init(constraints);
       
    });
}



//********************* End ******************//