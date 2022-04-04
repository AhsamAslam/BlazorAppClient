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
function StartRecording() {
let mediaRecorder;
let recordedBlobs;

const errorMsgElement = document.querySelector('span#errorMsg');
const recordedVideo = document.querySelector('video#recorded');
const recordButton = document.querySelector('button#record');
const playButton = document.querySelector('button#play');
const downloadButton = document.querySelector('button#download');
const saveButton = document.querySelector('button#save');


recordButton.addEventListener('click', () => {
    debugger;
    if (recordButton.textContent === 'Record') {
        startRecording();
    } else {
        stopRecording();
        recordButton.textContent = 'Record';
        playButton.disabled = false;
        downloadButton.disabled = false;
        saveButton.disabled = false;
    }
});


playButton.addEventListener('click', () => {
    debugger;
    const superBuffer = new Blob(recordedBlobs, { type: 'video/webm' });
    recordedVideo.src = null;
    recordedVideo.srcObject = null;
    recordedVideo.src = window.URL.createObjectURL(superBuffer);
    recordedVideo.controls = true;
    recordedVideo.play();
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
        const blob = new Blob(recordedBlobs, { type: 'video/mp4' });
        const url = window.URL.createObjectURL(blob);

        const a = document.createElement('a');
        a.style.display = 'none';
    a.href = url;

    //let xhr = new XMLHttpRequest();
    //xhr.open("POST", "http://localhost:5002/api/UploadWebCamVideo/UploadVideo");
    //xhr.setRequestHeader("Accept", "application/json");
    //xhr.setRequestHeader("Content-Type", "application/json");

    //xhr.onreadystatechange = function () {
    //    if (xhr.readyState === 4) {
    //        console.log(xhr.status);
    //        console.log(xhr.responseText);
    //    }
    //};
    //const JsonBlob = JSON.stringify(blob);

    //xhr.send(JsonBlob);
    var formData = new FormData();
    var fileName = "blob.mp4";


    var encodeData = new Blob(recordedBlobs, { type: 'multipart/form-data' });
    formData.append("blob", encodeData, fileName);

    var request = new XMLHttpRequest();
    request.open("POST", "http://localhost:5002/api/UploadWebCamVideo/UploadVideo", false);
    request.send(formData);


        a.download = 'test.mp4';
        document.body.appendChild(a);
        a.click();
        setTimeout(() => {
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        }, 100);
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
    recordButton.textContent = 'Stop Recording';
    playButton.disabled = true;
    downloadButton.disabled = true;
    mediaRecorder.onstop = (event) => {
        console.log('Recorder stopped: ', event);
        console.log('Recorded Blobs: ', recordedBlobs);
    };
    mediaRecorder.ondataavailable = handleDataAvailable;
    mediaRecorder.start();
    console.log('MediaRecorder started', mediaRecorder);
}

function stopRecording() {
    debugger;
    mediaRecorder.stop();
}

function handleSuccess(stream) {
    debugger;
    recordButton.disabled = false;
    console.log('getUserMedia() got stream:', stream);
    window.stream = stream;

    const gumVideo = document.querySelector('video#gum');
    gumVideo.srcObject = stream;
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


    
    document.querySelector('button#start').addEventListener('click', async () => {
        debugger;
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