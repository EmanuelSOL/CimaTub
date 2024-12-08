
/* BEGIN EXTERNAL SOURCE */

    // Simulación de datos de carreras y materias
    const careersData = [
        {
            name: "Software",
            subjects: ["Computo Bioinspirado", "Programación estructurada"]
        },
        {
            name: "Bioingeniería",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Civil",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Arquitectura",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Computación",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Industrial",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Nanotecnología",
            subjects: ["Materia 1", "Materia 2"]
        },
        {
            name: "Electrónica",
            subjects: ["Materia 1", "Materia 2"]
        }
    ];

    // Función para crear los elementos de la barra lateral
    function populateSidebar() {
        const careerList = document.getElementById("careerList");
        
        careersData.forEach(career => {
            const li = document.createElement("li");
            li.classList.add("career-item");
            
            // Crear el nombre de la carrera
            const careerName = document.createElement("span");
            careerName.classList.add("career-name");
            careerName.innerHTML = `${career.name} <span class="toggle">&#x25BC;</span>`;
            
            // Crear la lista de materias (oculta por defecto)
            const ulSubjects = document.createElement("ul");
            ulSubjects.classList.add("subjects-list");
            
            career.subjects.forEach(subject => {
                const liSubject = document.createElement("li");
                liSubject.textContent = subject;
                ulSubjects.appendChild(liSubject);
            });
            
            // Añadir la lista de materias debajo de la carrera
            li.appendChild(careerName);
            li.appendChild(ulSubjects);
            careerList.appendChild(li);
        });
    }

    // Llamar a la función para llenar la barra lateral
    populateSidebar();

    // Función para mostrar u ocultar las materias
    document.addEventListener('click', function(e) {
        if (e.target && e.target.matches('.career-name')) {
            const subjectList = e.target.nextElementSibling;
            if (subjectList) {
                subjectList.style.display = subjectList.style.display === 'none' ? 'block' : 'none';
                const toggle = e.target.querySelector('.toggle');
                toggle.innerHTML = toggle.innerHTML === '?' ? '?' : '?';
            }
        }
    });

/* END EXTERNAL SOURCE */
