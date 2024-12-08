
/* BEGIN EXTERNAL SOURCE */

        document.getElementById('es-docente').addEventListener('change', function () {
            const carreraContainer = document.getElementById('carrera-container');
            carreraContainer.style.display = this.value === 'no' ? 'block' : 'none';
        });
    
/* END EXTERNAL SOURCE */
