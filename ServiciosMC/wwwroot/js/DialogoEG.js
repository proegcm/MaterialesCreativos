const dialogoEG = ({
    type,
    title = '',
    mensaje,
    confirmar = '',
    cancelar = '',
    img, 
}) => {
    return new Promise(resolve => {
        const dialogo = document.querySelector('.dialog-wrapper');

        if (dialogo) {
            dialogo.remove();
        }


        const body = document.querySelector('body');
        const scripts = document.getElementsByTagName('script');
        let src = '';

        for (let script of scripts) {
            if (script.src.includes('DialogoEG.js')) {
                src = script.src.substring(0, script.src.lastIndexOf('/'));
            }
        }
        const template = `
    <div class="dialog-wrapper">
        <div class="dialog-frame">
            <div class="dialog-header ${type}-bg">
                ${img !== '' ? '<img class="dialog-img" src="' + src + '/' + img + '" />' : ''}
                <span class="dialog-text">${title}</span>
            </div>

            <div class="dialog-body">
                <span class="dialog-line"><strong>${mensaje}</strong></span>
                <div class="dialog-buttons">
                    <button class="confirmar-button ${type}-bg ${type}-btn">${confirmar}</button>
                    ${cancelar !== '' ? '<button class="cancelar-button cancelar-bg cancelar-btn">' + cancelar + '</button>' : ''}
                </div>
            </div>

      </div>
    </div>
    `;
        body.insertAdjacentHTML('afterend', template);

        const dialogWrapper = document.querySelector('.dialog-wrapper');
        const dialogFrame = document.querySelector('.dialog-frame');

        const confirmButton = document.querySelector('.confirmar-button');
        const cancelButton = document.querySelector('.cancelar-button');

        confirmButton.addEventListener('click', () => {
            dialogWrapper.remove();
            resolve('confirm');
        });
        if (cancelar !== '') {
            cancelButton.addEventListener('click', () => {
            dialogWrapper.remove();
            resolve();
        });
        }
        

        dialogFrame.addEventListener('click', e => {
            e.stopPropagation();
        });
    });
};



