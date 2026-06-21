const API = 'http://localhost:5000/api';

async function loadDirectors() {
    const res = await fetch(`${API}/directors`);
    const directors = await res.json();

    const list = document.getElementById('directors-list');
    directors.forEach(director => {
        const li = document.createElement('li');
        li.textContent = director.name;
        li.dataset.id = director.id;
        li.addEventListener('click', () => loadFilms(director.id, director.name));
        list.appendChild(li);
    });
}

async function loadFilms(directorId, directorName) {
    document.getElementById('films-heading').textContent = directorName;
    const grid = document.getElementById('films-grid');
    grid.innerHTML = '<p style="color:#aaa">Loading films...</p>';
    hideDetail();

    const res = await fetch(`${API}/directors/${directorId}`);
    const director = await res.json();

    grid.innerHTML = '';

    director.films.forEach(film => {
        const card = document.createElement('div');
        card.className = 'film-card';
        card.innerHTML = `<p class="film-title">${film.title} (${film.releaseYear})</p>`;
        card.addEventListener('click', () => loadFilmDetail(film.tmdbId));
        grid.appendChild(card);
    });

    director.films.forEach(async film => {
        const res = await fetch(`${API}/films/${film.tmdbId}`);
        const detail = await res.json();
        const cards = [...grid.querySelectorAll('.film-card')];
        const card = cards.find(c => c.querySelector('.film-title').textContent.startsWith(film.title));
        if (card && detail.posterUrl) {
            const img = document.createElement('img');
            img.src = detail.posterUrl;
            img.alt = film.title;
            card.prepend(img);
        }
    });
}

async function loadFilmDetail(filmId) {
    const res = await fetch(`${API}/films/${filmId}`);
    const film = await res.json();

    document.getElementById('detail-poster').src = film.posterUrl ?? '';
    document.getElementById('detail-title').textContent = film.title;
    document.getElementById('detail-score').textContent = `IMDb: ${film.imdbScore}`;
    document.getElementById('detail-overview').textContent = film.overview;

    const castList = document.getElementById('detail-cast');
    castList.innerHTML = '';
    film.cast.forEach(member => {
        const li = document.createElement('li');
        li.textContent = `${member.name} as ${member.character}`;
        castList.appendChild(li);
    });

    document.getElementById('detail-panel').classList.remove('hidden');
}

function hideDetail() {
    document.getElementById('detail-panel').classList.add('hidden');
}

document.getElementById('close-detail').addEventListener('click', hideDetail);

loadDirectors();