/**
* @requires Bootstrap
* @requires JQuery
* @author Khun LY
* @version 1.0.0
**/
const confirmBox = {
    /**
     * @param { {
     *      title: string, 
     *      content: string|HTMLElement,
     *      confirmContent: string|HTMLElement,
     *      cancelContent: string|HTMLElement,
     *      onConfirm: CallableFunction,
     *      onCancel: CallableFunction,
     * } } options
     **/
    show: (options) => {
        /** DOM creation */
        const modal = document.createElement('div');
        const modalDialog = document.createElement('div');
        const modalContent = document.createElement('div');
        const modalHeader = document.createElement('div');
        const modalTitle = document.createElement('div');
        const modalBody = document.createElement('div');
        const modalFooter = document.createElement('div');
        const cancelBtn = document.createElement('button');
        const confirmBtn = document.createElement('button');

        /** DOM classes */
        modal.classList.add('modal', 'fade');
        modalDialog.classList.add('modal-dialog');
        modalContent.classList.add('modal-content');
        modalHeader.classList.add('modal-header');
        modalTitle.classList.add('modal-title');
        modalBody.classList.add('modal-body');
        modalFooter.classList.add('modal-footer');
        cancelBtn.classList.add('btn', 'btn-secondary');
        confirmBtn.classList.add('btn', 'btn-danger');

        /** DOM content */
        modalTitle.innerText = options.title;
        modalBody.innerHTML = options.content;
        confirmBtn.innerHTML = options.confirmContent || 'Confirmer';
        cancelBtn.innerHTML = options.cancelContent || 'Annuler';

        /** DOM nesting */
        modalFooter.appendChild(cancelBtn);
        modalFooter.appendChild(confirmBtn);
        modalHeader.appendChild(modalTitle);
        modalContent.appendChild(modalHeader);
        modalContent.appendChild(modalBody);
        modalContent.appendChild(modalFooter);
        modalDialog.appendChild(modalContent);
        modal.appendChild(modalDialog);
        document.body.appendChild(modal);

        /** buttons Listeners */
        confirmBtn.addEventListener('click', options.onConfirm || (() => { }));
        cancelBtn.addEventListener('click', options.onCancel || (() => { }));
        confirmBtn.addEventListener('click', () => $(modal).modal('hide'));
        cancelBtn.addEventListener('click', () => $(modal).modal('hide'));

        /** modal on close */
        $(modal).on('hidden.bs.modal', () => {
            document.body.removeChild(modal);
        });

        /** show modal */
        $(modal).modal('show');

        return modal;
    }
}