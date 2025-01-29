import { useContext, useEffect, useState } from 'react';
import { ClipLoader } from 'react-spinners';
import { MovieCard } from '../../components';
import { MovieContext } from '../../context/movie-context';
import { useMoviesPage } from './useMoviesPage';

export const MoviesPage = () => {
    const { isLoading, handleSearch, noMovieFound, movies } = useMoviesPage();
    const { searchMovieName, updateSearchMovieName } = useContext(MovieContext);
    const [searchValue, setSearchValue] = useState('');
    const handleInput = (e: any) => {
        const fieldValue = e.nativeEvent.target.value;
        setSearchValue(fieldValue);
        updateSearchMovieName(fieldValue);
    }

    useEffect(() => {
        if (!searchMovieName) return;

        setSearchValue(searchMovieName);
    }, [searchMovieName])

    return (
        <div className="flex-row">
            <div className="w-[900px] mx-auto justify-center flex mt-10">
                <div className="w-full">
                    <p className="text-3xl font-bold my-2">Movies App</p>
                    <div className="mx-auto justify-center flex-row p-4">
                        <div className="flex justify-items-center content-center gap-x-4 mt-2">
                            <p className="font-semibold">Search By Name:</p>
                            <input defaultValue={searchValue} name='searchValue' type="text" className="text-black w-2/4 py-1 px-2 border rounded-lg" onChange={handleInput} />
                            <button className="px-4 mx-2 border rounded-lg bg-blue-200 py-1" onClick={() => handleSearch(searchValue)}>Search</button>
                        </div>
                    </div>
                    <div className="flex justify-center">
                        {
                            isLoading &&
                            <ClipLoader
                                loading={isLoading}
                                size={150}
                                aria-label="Loading Spinner"
                                data-testid="loader"
                            />
                        }
                    </div>
                    <div className="p-3 flex flex-wrap gap-8">
                        {noMovieFound && <p>No Movies found</p>}
                        {movies?.map((p, indx) => {
                            return <MovieCard key={`${p.name}-${indx}`} movie={p} />
                        })}
                    </div>
                </div>
            </div>
        </div>
    );
};