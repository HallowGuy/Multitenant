export default function Header() {
  return (
    <header className="bg-white shadow-md p-4 fixed top-0 w-full z-50">
      <div className="container mx-auto flex justify-between items-center">
        <h1 className="text-xl font-bold text-black">MoonSite</h1>
        <nav className="space-x-4">
          <a href="/" className="text-black hover:text-[#00AE8D]">Accueil</a>
          <a href="/create" className="text-black hover:text-[#C6007E]">Créer</a>
        </nav>
      </div>
    </header>
  );
}
