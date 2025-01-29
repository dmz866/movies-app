import { Link } from "react-router";

type TProps = {
    links: { name: string, path: string }[];
};

export const Header = ({ links }: TProps) => {
    return (
        <div className="flex justify-end gap-x-8 mx-4 mt-4 font-bold">
            {
                links.map(link => (
                    <Link className="hover:underline" key={link.name} to={link.path}>{link.name}</Link>
                ))
            }
        </div>
    );
}