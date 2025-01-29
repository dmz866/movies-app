import { useCallback } from 'react';
import { useNavigate } from 'react-router';
import { ToastContainer } from 'react-toastify';
import { ACTORS_PATH, MOVIES_PATH } from '../../constants/route-paths';

export const HomePage = () => {
    const navigate = useNavigate();
    const navigateTo = useCallback((route: string) => {
        navigate(route);
    },
        [navigate]);

    return (
        <>
            <div className="flex-row">
                <div className="w-[800px] mx-auto justify-center flex mt-10">
                    <div className="w-full">
                        <p className="text-3xl font-bold my-2">Movies App</p>
                        <div className="flex justify-center gap-4">
                            <div onClick={() => navigateTo(MOVIES_PATH)}>
                                <p className="text-3xl font-bold my-2">Movies</p>
                                <img className='hover:cursor-pointer' alt='movie' src='/images/movie.jpeg' height={100} width={100} />
                            </div>
                            <div onClick={() => navigateTo(ACTORS_PATH)}>
                                <p className="text-3xl font-bold my-2">Actors</p>
                                <img className='hover:cursor-pointer' alt='actors' src='/images/rock.jpg' height={100} width={100} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <ToastContainer />
        </>
    );
};