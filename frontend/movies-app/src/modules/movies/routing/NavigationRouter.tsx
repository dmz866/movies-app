import { BrowserRouter, Route, Routes } from 'react-router';
import { Header } from '../../common/components';
import { ACTOR__DETAILS_PATH, ACTORS_PATH, MOVIE_DETAILS_PATH, MOVIES_PATH } from '../constants';
import { ActorDetailsPage } from '../pages/ActorDetailsPage/ActorDetailsPage';
import { ActorsPage } from '../pages/ActorsPage/ActorsPage';
import { HomePage } from '../pages/HomePage/HomePage';
import { MovieDetailsPage } from '../pages/MovieDetailsPage/MovieDetailsPage';
import { MoviesPage } from '../pages/MoviesPage/MoviesPage';

const headerLinks = [
    {
        name: 'Movies',
        path: MOVIES_PATH
    },
    {
        name: 'Actors',
        path: ACTORS_PATH
    }
];

export const NavigationRouter = () => {
    return (
        <div className="bg-movies h-full">
            <BrowserRouter>
                <Header links={headerLinks} />
                <Routes>
                    <Route path='/' element={<HomePage />} />
                    <Route path={MOVIES_PATH} element={<MoviesPage />} />
                    <Route path={ACTORS_PATH} element={<ActorsPage />} />
                    <Route path={MOVIE_DETAILS_PATH} element={<MovieDetailsPage />} />
                    <Route path={ACTOR__DETAILS_PATH} element={<ActorDetailsPage />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}
